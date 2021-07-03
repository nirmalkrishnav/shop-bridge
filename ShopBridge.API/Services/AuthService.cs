using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShopBridge.DTOs; 
using ShopBridge.Entities;
using ShopBridge.Interfaces.Service;
using System;
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
            try
            {

                var result = await _userManager.CheckPasswordAsync(user, model.Password);
                if (result)
                {

                    return new TokenResult()
                    {
                        Token = GenerateJWT(user.Id),
                        Success = true
                    };
                }
                else
                {
                    return new TokenResult()
                    {
                        Success = false,
                        Errors = "Invalid user"
                    };
                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);

            }
        }
        private string GenerateJWT(int userId)
        {
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                   {
                        new Claim(ClaimTypes.NameIdentifier , userId.ToString())
                   }),
                Expires = DateTime.UtcNow.Add(_applicationSecret.TokenLifeSpan),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_applicationSecret.Secret)), SecurityAlgorithms.HmacSha256),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescription);
            var token = tokenHandler.WriteToken(securityToken);
            return token;
        }

    }


}
