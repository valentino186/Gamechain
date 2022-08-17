using Gamechain.Application.Contracts.Dtos.Auth;
using Gamechain.Application.Contracts.Interfaces.AppServices;
using Gamechain.Application.Contracts.Interfaces.Repositories;
using Gamechain.Domain.Entities.Aggregates.User;
using Microsoft.AspNetCore.Identity;

namespace Gamechain.Application.AppServices.Auth
{
    public class AuthAppService : IAuthAppService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthRepository _authRepository;

        public AuthAppService(UserManager<ApplicationUser> userManager, 
            IAuthRepository authRepository)
        {
            _userManager = userManager;
            _authRepository = authRepository;
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserName);

            if (user == null)
            {
                throw new Exception("Incorrect username or password.");
            }

            var correctPassword = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!correctPassword)
            {
                throw new Exception("Incorrect username or password.");
            }

            return _authRepository.GetToken(user);
        }
    }
}
