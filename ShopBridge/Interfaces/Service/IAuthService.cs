using Microsoft.AspNetCore.Identity;
using ShopBridge.DTOs;
using System.Threading.Tasks;

namespace ShopBridge.Interfaces.Service
{
    public interface IAuthService
    {
        Task<TokenResult> Login(TokenRequest model);
        Task<bool> Register(User user);
        Task<TokenResult> Reset(TokenRequest model);

    }
}
