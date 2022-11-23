using Gamechain.Application.Common.Responses;
using Gamechain.Application.Services.Platforms.Commands.CreatePlatform;
using Gamechain.Application.Services.Platforms.Commands.DeletePlatform;
using Gamechain.Application.Services.Platforms.Commands.UpdatePlatform;
using Gamechain.Application.Services.Platforms.Queries.GetPlatforms;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gamechain.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformController : ControllerBase
    {
        private readonly ISender _mediator;

        public PlatformController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<List<PlatformResponse>> GetPlatforms()
        {
            return _mediator.Send(new GetPlatformsQuery());
        }

        [HttpPost]
        public Task<PlatformResponse> CreatePlatform([FromBody] CreatePlatformCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpPut("{platformId}")]
        public Task<PlatformResponse> UpdatePlatform([FromBody] UpdatePlatformCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpDelete("{platformId}")]
        public Task DeletePlatform(Guid platformId)
        {
            var command = new DeletePlatformCommand(platformId);

            return _mediator.Send(command);
        }
    }
}
