using Gamechain.Application.Common.Responses;
using Gamechain.Application.Services.Games.Commands.CreateGame;
using Gamechain.Application.Services.Games.Commands.UpdateGame;
using Gamechain.Application.Services.Games.Queries.GetPublisherGames;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gamechain.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ISender _mediator;

        public GameController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("Publisher/{publisherId}")]
        public Task<List<GameResponse>> GetPublisherGames(Guid publisherId)
        {
            var query = new GetPublisherGamesQuery(publisherId);

            return _mediator.Send(query);
        }

        [HttpPost]
        public Task<GameResponse> CreateGame([FromBody] CreateGameCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpPut]
        public Task<GameResponse> UpdateGame([FromBody] UpdateGameCommand command)
        {
            return _mediator.Send(command);
        }
    }
}
