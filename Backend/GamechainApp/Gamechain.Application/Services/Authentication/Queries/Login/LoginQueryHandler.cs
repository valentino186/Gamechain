﻿using AutoMapper;
using Gamechain.Application.Common.Responses;
using Gamechain.Application.Interfaces.Repositories;
using Gamechain.Domain.Entities.Aggregates.User;
using Gamechain.Domain.Exceptions;
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
                throw new LoginException();
            }

            var correctPassword = await _userManager.CheckPasswordAsync(user, query.Password);

            if (!correctPassword)
            {
                throw new LoginException();
            }

            var loginResponse = _mapper.Map<LoginResponse>(user);
            {
                loginResponse.Token = _authRepository.GetToken(user);
            }

            return loginResponse;
        }
    }
}
