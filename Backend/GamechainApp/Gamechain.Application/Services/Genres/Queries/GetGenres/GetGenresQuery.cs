using Gamechain.Application.Common.Responses;
using MediatR;

namespace Gamechain.Application.Services.Genres.Queries.GetGenres
{
    public record GetGenresQuery : IRequest<List<GenreResponse>>
    {
    }
}
