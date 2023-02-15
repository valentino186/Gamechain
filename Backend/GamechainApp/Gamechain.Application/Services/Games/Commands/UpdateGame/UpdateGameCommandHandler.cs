using AutoMapper;
using Gamechain.Application.Common.Responses;
using Gamechain.Application.Interfaces.Repositories;
using Gamechain.Domain.Entities.Aggregates.Game;
using Gamechain.Domain.Exceptions;
using MediatR;

namespace Gamechain.Application.Services.Games.Commands.UpdateGame
{
    public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, GameResponse>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public UpdateGameCommandHandler(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<GameResponse> Handle(UpdateGameCommand command, CancellationToken cancellationToken)
        {
            var game = await _gameRepository.GetGameWithDetails(command.Id);

            if (game == null)
            {
                throw new EntityNotFoundException(typeof(Game));
            }

            game.SetName(command.Name);
            game.SetDescription(command.Description);
            game.SetPrice(command.Price);
            game.SetDiscount(command.Discount);

            List<GameFeature> features = new List<GameFeature>();
            List<GameGenre> genres = new List<GameGenre>();
            List<GamePlatform> platforms = new List<GamePlatform>();

            foreach (Guid featureId in command.FeatureIds)
            {
                features.Add(new GameFeature(game.Id, featureId));
            }

            foreach (Guid genreId in command.GenreIds)
            {
                genres.Add(new GameGenre(game.Id, genreId));
            }

            foreach (Guid platformId in command.PlatformIds)
            {
                platforms.Add(new GamePlatform(game.Id, platformId));
            }

            game.SetFeatures(features);
            game.SetGenres(genres);
            game.SetPlatforms(platforms);

            await _gameRepository.Update(game);

            return _mapper.Map<GameResponse>(game);
        }
    }
}
