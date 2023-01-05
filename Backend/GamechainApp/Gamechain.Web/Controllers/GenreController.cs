using Gamechain.Application.Common.Responses;
using Gamechain.Application.Services.Genres.Commands.CreateGenre;
using Gamechain.Application.Services.Genres.Commands.DeleteGenre;
using Gamechain.Application.Services.Genres.Commands.UpdateGenre;
using Gamechain.Application.Services.Genres.Queries.GetGenres;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gamechain.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly ISender _mediator;

        public GenreController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<List<GenreResponse>> GetGenres()
        {
            return _mediator.Send(new GetGenresQuery());
        }

        [HttpPost]
        public Task<GenreResponse> CreateGenre([FromBody] CreateGenreCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpPut]
        public Task<GenreResponse> UpdateGenre([FromBody] UpdateGenreCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpDelete("{genreId}")]
        public Task DeleteGenre(Guid genreId)
        {
            var command = new DeleteGenreCommand(genreId);

            return _mediator.Send(command);
        }
    }
}
