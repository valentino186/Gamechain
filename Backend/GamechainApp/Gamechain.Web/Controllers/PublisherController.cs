using Gamechain.Application.Services.Publishers.Commands.CreatePublisher;
using Gamechain.Application.Services.Publishers.Queries.GetPublishers;
using Gamechain.Application.Contracts.Common.Responses;
using Gamechain.Application.Contracts.Requests.Publishers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Gamechain.Application.Services.Publishers.Commands.DeletePublisher;

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
        public Task<PublisherResponse> CreatePublisher([FromBody] CreatePublisherRequest request)
        {
            var command = new CreatePublisherCommand(request.Name);

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
