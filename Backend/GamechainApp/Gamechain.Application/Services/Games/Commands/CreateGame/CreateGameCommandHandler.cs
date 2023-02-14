using AutoMapper;
using Gamechain.Application.Common.Responses;
using Gamechain.Application.Interfaces.Repositories;
using Gamechain.Domain.Entities.Aggregates.Game;
using MediatR;

namespace Gamechain.Application.Services.Games.Commands.CreateGame
{
    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, GameResponse>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public CreateGameCommandHandler(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<GameResponse> Handle(CreateGameCommand command, CancellationToken cancellationToken)
        {
            Guid gameId = Guid.NewGuid();

            var game = new Game(
                gameId,
                command.PublisherId,
                command.Name,
                command.Description,
                command.Price,
                command.Discount);

            foreach (Guid featureId in command.FeatureIds)
            {
                game.AddFeature(new GameFeature(gameId, featureId));
            }

            foreach (Guid genreId in command.GenreIds)
            {
                game.AddGenre(new GameGenre(gameId, genreId));
            }

            foreach (Guid platformId in command.PlatformIds)
            {
                game.AddPlatform(new GamePlatform(gameId, platformId));
            }

            await _gameRepository.Create(game);

            return _mapper.Map<GameResponse>(game);
        }
    }
}
