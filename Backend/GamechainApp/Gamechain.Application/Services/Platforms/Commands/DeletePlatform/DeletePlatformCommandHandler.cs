using Gamechain.Application.Interfaces.Repositories;
using Gamechain.Domain.Entities.Aggregates.Platform;
using Gamechain.Domain.Exceptions;
using MediatR;

namespace Gamechain.Application.Services.Platforms.Commands.DeletePlatform
{
    public class DeletePlatformCommandHandler : IRequestHandler<DeletePlatformCommand>
    {
        private readonly IPlatformRepository _platformRepository;

        public DeletePlatformCommandHandler(IPlatformRepository platformRepository)
        {
            _platformRepository = platformRepository;
        }

        public async Task<Unit> Handle(DeletePlatformCommand command, CancellationToken cancellationToken)
        {
            var platform = await _platformRepository.GetById(command.Id);

            if (platform == null)
            {
                throw new EntityNotFoundException(typeof(Platform));
            }

            await _platformRepository.Delete(platform);

            return Unit.Value;
        }
    }
}
