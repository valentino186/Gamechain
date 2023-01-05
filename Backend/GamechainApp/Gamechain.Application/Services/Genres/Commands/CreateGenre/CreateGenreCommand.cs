using Gamechain.Application.Common.Responses;
using MediatR;

namespace Gamechain.Application.Services.Genres.Commands.CreateGenre
{
    public record CreateGenreCommand(string Name) : IRequest<GenreResponse>
    {
    }
}
