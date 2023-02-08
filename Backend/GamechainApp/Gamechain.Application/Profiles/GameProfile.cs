using AutoMapper;
using Gamechain.Application.Common.Responses;
using Gamechain.Domain.Entities.Aggregates.Game;

namespace Gamechain.Application.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameResponse>();
        }
    }
}
