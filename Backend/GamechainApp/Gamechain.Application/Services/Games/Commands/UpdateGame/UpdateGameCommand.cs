using Gamechain.Application.Common.Responses;
using MediatR;

namespace Gamechain.Application.Services.Games.Commands.UpdateGame
{
    public record UpdateGameCommand(
        Guid Id,
        Guid PublisherId,
        string Name,
        string Description,
        decimal Price,
        double Discount,
        List<Guid> FeatureIds,
        List<Guid> GenreIds,
        List<Guid> PlatformIds) : IRequest<GameResponse>
    {
    }
}
