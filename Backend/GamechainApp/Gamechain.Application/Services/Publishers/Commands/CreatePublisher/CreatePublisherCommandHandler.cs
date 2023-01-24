using AutoMapper;
using Gamechain.Application.Common.Responses;
using Gamechain.Application.Interfaces.Repositories.Common;
using Gamechain.Domain.Entities.Aggregates.Publisher;
using MediatR;

namespace Gamechain.Application.Services.Publishers.Commands.CreatePublisher
{
    public class CreatePublisherCommandHandler : IRequestHandler<CreatePublisherCommand, PublisherResponse>
    {
        private readonly IRepository<Publisher> _publisherRepository;
        private readonly IMapper _mapper;

        public CreatePublisherCommandHandler(IRepository<Publisher> publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<PublisherResponse> Handle(CreatePublisherCommand command, CancellationToken cancellationToken)
        {
            var publisher = new Publisher(command.Name);

            await _publisherRepository.Create(publisher);

            return _mapper.Map<PublisherResponse>(publisher);
        }
    }
}
