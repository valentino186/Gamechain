using AutoMapper;
using Gamechain.Application.Contracts.Common.Responses;
using Gamechain.Application.Contracts.Interfaces.AppServices;
using Gamechain.Application.Contracts.Interfaces.Repositories;
using Gamechain.Application.Contracts.Requests.Auth;
using Gamechain.Domain.Entities.Aggregates.User;
using Microsoft.AspNetCore.Identity;

namespace Gamechain.Application.AppServices.Auth
{
    public class AuthAppService : IAuthAppService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;

        public AuthAppService(UserManager<ApplicationUser> userManager, 
            IAuthRepository authRepository,
            IMapper mapper)
        {
            _userManager = userManager;
            _authRepository = authRepository;
            _mapper = mapper;
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByNameAsync(loginRequest.UserName);

            if (user == null)
            {
                throw new Exception("Incorrect username or password.");
            }

            var correctPassword = await _userManager.CheckPasswordAsync(user, loginRequest.Password);

            if (!correctPassword)
            {
                throw new Exception("Incorrect username or password.");
            }

            var loginResponse = _mapper.Map<LoginResponse>(user);
            {
                loginResponse.Token = _authRepository.GetToken(user);
            }

            return loginResponse;
        }
    }
}
