using AutoMapper;
using Gamechain.Application.Common.Responses;
using Gamechain.Domain.Entities.Aggregates.Genre;

namespace Gamechain.Application.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreResponse>();
        }
    }
}
