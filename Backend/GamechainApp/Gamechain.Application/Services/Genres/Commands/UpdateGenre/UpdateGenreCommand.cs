using Gamechain.Application.Common.Responses;
using MediatR;

namespace Gamechain.Application.Services.Genres.Commands.UpdateGenre
{
    public record UpdateGenreCommand(
        Guid Id,
        string Name) : IRequest<GenreResponse>
    {
    }
}
