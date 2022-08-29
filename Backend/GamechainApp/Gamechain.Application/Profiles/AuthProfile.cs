using AutoMapper;
using Gamechain.Application.Contracts.Common.Responses;
using Gamechain.Domain.Entities.Aggregates.User;

namespace Gamechain.Application.Profiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<ApplicationUser, LoginResponse>();
        }
    }
}
