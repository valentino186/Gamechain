using MediatR;

namespace Gamechain.Application.Services.Games.Commands.DeleteGame
{
    public record DeleteGameCommand(Guid Id) : IRequest
    {
    }
}
