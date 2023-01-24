using AutoMapper;
using Gamechain.Application.Common.Responses;
using Gamechain.Domain.Entities.Aggregates.Publisher;

namespace Gamechain.Application.Profiles
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher, PublisherResponse>();
        }
    }
}
