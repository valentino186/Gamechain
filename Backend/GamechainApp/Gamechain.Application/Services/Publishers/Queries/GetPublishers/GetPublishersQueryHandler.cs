using AutoMapper;
using Gamechain.Application.Common.Responses;
using Gamechain.Application.Interfaces.Repositories.Common;
using Gamechain.Domain.Entities.Aggregates.Publisher;
using MediatR;

namespace Gamechain.Application.Services.Publishers.Queries.GetPublishers
{
    public class GetPublishersQueryHandler : IRequestHandler<GetPublishersQuery, List<PublisherResponse>>
    {
        private readonly IRepository<Publisher> _publisherRepository;
        private readonly IMapper _mapper;

        public GetPublishersQueryHandler(IRepository<Publisher> publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<List<PublisherResponse>> Handle(GetPublishersQuery query, CancellationToken cancellationToken)
        {
            var publishers = await _publisherRepository.GetAll();

            return _mapper.Map<List<PublisherResponse>>(publishers);
        }
    }
}
