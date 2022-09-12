using AutoMapper;
using Gamechain.Application.Contracts.Common.Responses;
using Gamechain.Application.Contracts.Interfaces.AppServices;
using Gamechain.Application.Contracts.Interfaces.Repositories;
using Gamechain.Domain.Entities.Aggregates.Publisher;
using Gamechain.Domain.Exceptions;

namespace Gamechain.Application.AppServices.Publishers
{
    public class PublisherAppService : IPublisherAppService
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public PublisherAppService(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<List<PublisherResponse>> GetPublishers()
        {
            var publishers = await _publisherRepository.GetAll();

            return _mapper.Map<List<PublisherResponse>>(publishers);
        }

        public async Task<PublisherResponse> GetPublisherById(Guid publisherId)
        {
            var publisher = await _publisherRepository.GetById(publisherId);

            if (publisher == null)
            {
                throw new EntityNotFoundException(typeof(Publisher));
            }

            return _mapper.Map<PublisherResponse>(publisher);
        }
    }
}
