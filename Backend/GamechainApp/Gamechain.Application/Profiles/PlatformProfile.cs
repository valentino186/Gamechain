using AutoMapper;
using Gamechain.Application.Common.Responses;
using Gamechain.Domain.Entities.Aggregates.Platform;

namespace Gamechain.Application.Profiles
{
    public class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            CreateMap<Platform, PlatformResponse>();
        }
    }
}
