using AutoMapper;
using Gamechain.Application.Contracts.Common.Responses;
using Gamechain.Application.Services.Publishers.Commands.CreatePublisher;
using Gamechain.Application.Services.Publishers.Commands.UpdatePublisher;
using Gamechain.Domain.Entities.Aggregates.Publisher;

namespace Gamechain.Application.Profiles
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher, PublisherResponse>();
            CreateMap<CreatePublisherCommand, Publisher>();
            CreateMap<UpdatePublisherCommand, Publisher>();
        }
    }
}
