using AutoMapper;
using Gamechain.Application.Common.Responses;
using Gamechain.Application.Interfaces.Repositories;
using Gamechain.Domain.Entities.Aggregates.Publisher;
using Gamechain.Domain.Exceptions;
using MediatR;

namespace Gamechain.Application.Services.Publishers.Queries.GetPublisher
{
    public class GetPublisherQueryHandler : IRequestHandler<GetPublisherQuery, PublisherResponse>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public GetPublisherQueryHandler(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<PublisherResponse> Handle(GetPublisherQuery query, CancellationToken cancellationToken)
        {
            var publisher = await _publisherRepository.GetById(query.Id);

            if (publisher == null)
            {
                throw new EntityNotFoundException(typeof(Publisher));
            }

            return _mapper.Map<PublisherResponse>(publisher);
        }
    }
}
