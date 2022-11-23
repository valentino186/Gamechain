using Gamechain.Application.Common.Responses;
using Gamechain.Application.Services.Publishers.Commands.CreatePublisher;
using Gamechain.Application.Services.Publishers.Commands.DeletePublisher;
using Gamechain.Application.Services.Publishers.Commands.UpdatePublisher;
using Gamechain.Application.Services.Publishers.Queries.GetPublishers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gamechain.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublisherController : ControllerBase
    {
        private readonly ISender _mediator;

        public PublisherController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<List<PublisherResponse>> GetPublishers()
        {
            return _mediator.Send(new GetPublishersQuery());
        }

        [HttpPost]
        public Task<PublisherResponse> CreatePublisher([FromBody] CreatePublisherCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpPut]
        public Task<PublisherResponse> UpdatePublisher([FromBody] UpdatePublisherCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpDelete("{publisherId}")]
        public Task DeletePublisher(Guid publisherId)
        {
            var command = new DeletePublisherCommand(publisherId);

            return _mediator.Send(command);
        }
    }
}
