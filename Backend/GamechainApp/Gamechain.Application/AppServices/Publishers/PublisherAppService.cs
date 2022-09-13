using AutoMapper;
using Gamechain.Application.Contracts.Common.Responses;
using Gamechain.Application.Contracts.Interfaces.AppServices;
using Gamechain.Application.Contracts.Interfaces.Repositories;
using Gamechain.Application.Contracts.Requests.Publishers;
using Gamechain.Domain.Entities.Aggregates.Publisher;
using Gamechain.Domain.Exceptions;

namespace Gamechain.Application.AppServices.Publishers
{
    public class PublisherAppService : IPublisherAppService
    {
        private readonly IRepository<Publisher> _publisherRepository;
        private readonly IMapper _mapper;

        public PublisherAppService(IRepository<Publisher> publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<List<PublisherResponse>> GetPublishers()
        {
            var publishers = await _publisherRepository.GetAll();

            return _mapper.Map<List<PublisherResponse>>(publishers);
        }

        public async Task<PublisherResponse> CreatePublisher(CreatePublisherRequest request)
        {
            var publisherToCreate = _mapper.Map<Publisher>(request);

            await _publisherRepository.Create(publisherToCreate);

            return _mapper.Map<PublisherResponse>(publisherToCreate);
        }
    }
}
