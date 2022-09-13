using AutoMapper;
using Gamechain.Application.Contracts.Common.Responses;
using Gamechain.Application.Contracts.Requests.Publishers;
using Gamechain.Domain.Entities.Aggregates.Publisher;

namespace Gamechain.Application.Profiles
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher, PublisherResponse>();
            CreateMap<CreatePublisherRequest, Publisher>();
        }
    }
}
