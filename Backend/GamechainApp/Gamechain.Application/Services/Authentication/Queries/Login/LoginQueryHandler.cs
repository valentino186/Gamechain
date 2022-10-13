using AutoMapper;
using Gamechain.Application.Contracts.Common.Responses;
using Gamechain.Application.Contracts.Interfaces.Repositories;
using Gamechain.Domain.Entities.Aggregates.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Gamechain.Application.Services.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;

        public LoginQueryHandler(UserManager<ApplicationUser> userManager, IAuthRepository authRepository, IMapper mapper)
        {
            _userManager = userManager;
            _authRepository = authRepository;
            _mapper = mapper;
        }

        public async Task<LoginResponse> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(query.UserName);

            if (user == null)
            {
                throw new Exception("Incorrect username or password.");
            }

            var correctPassword = await _userManager.CheckPasswordAsync(user, query.Password);

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
