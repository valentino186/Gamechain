using AutoMapper;
using Gamechain.Application.Contracts.Common.Responses;
using Gamechain.Application.Contracts.Interfaces.Repositories;
using Gamechain.Domain.Entities.Aggregates.Publisher;
using Gamechain.Domain.Exceptions;
using MediatR;

namespace Gamechain.Application.Services.Publishers.Commands.UpdatePublisher
{
    public class UpdatePublisherCommandHandler : IRequestHandler<UpdatePublisherCommand, PublisherResponse>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public UpdatePublisherCommandHandler(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<PublisherResponse> Handle(UpdatePublisherCommand command, CancellationToken cancellationToken)
        {
            var publisher = await _publisherRepository.GetById(command.Id);

            if (publisher == null)
            {
                throw new EntityNotFoundException(typeof(Publisher));
            }

            _mapper.Map(command, publisher);

            await _publisherRepository.Update(publisher);

            return _mapper.Map<PublisherResponse>(publisher);
        }
    }
}
