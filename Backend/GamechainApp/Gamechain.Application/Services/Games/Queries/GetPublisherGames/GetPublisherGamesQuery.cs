using Gamechain.Application.Common.Responses;
using MediatR;

namespace Gamechain.Application.Services.Games.Queries.GetPublisherGames
{
    public record GetPublisherGamesQuery(
        Guid PublisherId) : IRequest<List<GameResponse>>
    {
    }
}
