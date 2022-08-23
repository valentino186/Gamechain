using Gamechain.Application.Contracts.Common.Responses;
using Gamechain.Application.Contracts.Requests.Auth;

namespace Gamechain.Application.Contracts.Interfaces.AppServices
{
    public interface IAuthAppService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
    }
}
