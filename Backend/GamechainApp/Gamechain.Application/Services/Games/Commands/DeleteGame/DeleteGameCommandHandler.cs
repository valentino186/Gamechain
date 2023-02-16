using Gamechain.Application.Interfaces.Repositories;
using Gamechain.Domain.Entities.Aggregates.Game;
using Gamechain.Domain.Exceptions;
using MediatR;

namespace Gamechain.Application.Services.Games.Commands.DeleteGame
{
    public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand>
    {
        private readonly IGameRepository _gameRepository;

        public DeleteGameCommandHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<Unit> Handle(DeleteGameCommand command, CancellationToken cancellationToken)
        {
            var game = await _gameRepository.GetById(command.Id);

            if (game == null)
            {
                throw new EntityNotFoundException(typeof(Game));
            }

            await _gameRepository.Delete(game);

            return Unit.Value;
        }
    }
}
