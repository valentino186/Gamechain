using AutoMapper;
using Gamechain.Application.Common.Responses;
using Gamechain.Application.Interfaces.Repositories;
using MediatR;

namespace Gamechain.Application.Services.Games.Queries.GetPublisherGames
{
    public class GetPublisherGamesQueryHandler : IRequestHandler<GetPublisherGamesQuery, List<GameResponse>>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GetPublisherGamesQueryHandler(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }


        public async Task<List<GameResponse>> Handle(GetPublisherGamesQuery query, CancellationToken cancellationToken)
        {
            var games = await _gameRepository.GetPublisherGames(query.PublisherId);

            return _mapper.Map<List<GameResponse>>(games);
        }
    }
}
