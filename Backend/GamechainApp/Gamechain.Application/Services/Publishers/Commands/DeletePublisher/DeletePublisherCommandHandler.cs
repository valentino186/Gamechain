using Gamechain.Application.Interfaces.Repositories;
using Gamechain.Domain.Entities.Aggregates.Publisher;
using Gamechain.Domain.Exceptions;
using MediatR;

namespace Gamechain.Application.Services.Publishers.Commands.DeletePublisher
{
    public class DeletePublisherCommandHandler : IRequestHandler<DeletePublisherCommand>
    {
        private readonly IPublisherRepository _publisherRepository;

        public DeletePublisherCommandHandler(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public async Task<Unit> Handle(DeletePublisherCommand command, CancellationToken cancellationToken)
        {
            var publisher = await _publisherRepository.GetById(command.Id);

            if (publisher == null)
            {
                throw new EntityNotFoundException(typeof(Publisher));
            }

            await _publisherRepository.Delete(publisher);

            return Unit.Value;
        }
    }
}
