using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShopBridge.DTOs;
using ShopBridge.Entities;
using ShopBridge.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Service
{

    public class AuthService : IAuthService
    {
        //readonly SignInManager<AppUser> _signInManager;
        readonly UserManager<AppUser> _userManager;


        private readonly TokenSettings _applicationSecret;

        public AuthService(
            UserManager<AppUser> userManager,
                IOptions<TokenSettings> applicationSecret
            )
        {
            _userManager = userManager;
            _applicationSecret = applicationSecret.Value;

        }

        public async Task<bool> Register(User newUser)
        {
            var user = new AppUser { UserName = newUser.UserName, Email = newUser.UserName };
            IdentityResult result = await _userManager.CreateAsync(user, newUser.Password);

            if (!result.Succeeded)
            {
                return false;
            }
            await _userManager.AddToRoleAsync(user, "Admin");
            return true;
        }

        public async Task<TokenResult> Login(TokenRequest model)
        {


            var user = await _userManager.FindByEmailAsync(model.Username);
            if (user == null)
            {
                return new TokenResult()
                {
                    Success = false,
                    Errors = "Invalid Credentials"
                };
            }

            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            if (result)
            {

                var userRoles = await _userManager.GetRolesAsync(user);
                return new TokenResult()
                {
                    Token = GenerateJWT(user.Id, userRoles),
                    Success = true
                };
            }
            else
            {
                return new TokenResult()
                {
                    Success = false,
                    Errors = "Invalid Credentials"
                };
            }

        }
        private string GenerateJWT(int userId, IList<string> roles)
        {

            var tokenDescription = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new Claim[]
               {
                        new Claim(ClaimTypes.NameIdentifier , userId.ToString()),
                        new Claim(ClaimTypes.Role , string.Join(",", roles)),

               }),
                Expires = DateTime.UtcNow.Add(_applicationSecret.TokenLifeSpan),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_applicationSecret.Secret)), SecurityAlgorithms.HmacSha256),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescription);
            var token = tokenHandler.WriteToken(securityToken);
            return token;
        }


        //
        // Summary: Insecure way to resets password for an existing user
        //
        // TODO:  Need 2 factor auth in this process
        //
        public async Task<TokenResult> Reset(TokenRequest model)
        {
            var user = await _userManager.FindByEmailAsync(model.Username);
            if (user == null)
            {
                return new TokenResult()
                {
                    Success = false,
                    Errors = "Invalid user"
                };
            }

            var identityResult = await _userManager.RemovePasswordAsync(user);
            if (!identityResult.Succeeded)
                throw new InvalidOperationException("Password reset failed");

            identityResult = await _userManager.AddPasswordAsync(user, model.Password);
            if (!identityResult.Succeeded)
                throw new InvalidOperationException("Failed to update your new password. Check the password complexity requirements");

            identityResult = await _userManager.UpdateAsync(user);
            if (!identityResult.Succeeded)
                throw new InvalidOperationException("Updation of user failed");
            await _userManager.AddToRoleAsync(user, "Admin");
            return await Login(model);

        }


    }


}
