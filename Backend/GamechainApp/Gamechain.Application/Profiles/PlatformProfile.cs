using AutoMapper;
using Gamechain.Application.Common.Responses;
using Gamechain.Application.Services.Platforms.Commands.CreatePlatform;
using Gamechain.Application.Services.Platforms.Commands.UpdatePlatform;
using Gamechain.Domain.Entities.Aggregates.Platform;

namespace Gamechain.Application.Profiles
{
    public class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            CreateMap<Platform, PlatformResponse>();
            CreateMap<CreatePlatformCommand, Platform>();
            CreateMap<UpdatePlatformCommand, Platform>();
        }
    }
}
