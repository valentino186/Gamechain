using Gamechain.Application.Contracts.Dtos.Auth;

namespace Gamechain.Application.Contracts.Interfaces.AppServices
{
    public interface IAuthAppService
    {
        Task<string> Login(LoginDto loginDto);
    }
}
