using Gamechain.Application.Common.Responses;
using MediatR;

namespace Gamechain.Application.Services.Genres.Commands.DeleteGenre
{
    public record DeleteGenreCommand(
        Guid Id) : IRequest
    {
    }
}
