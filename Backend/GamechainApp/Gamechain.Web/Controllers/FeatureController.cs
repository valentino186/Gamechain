using Gamechain.Application.Common.Responses;
using Gamechain.Application.Services.Features.Commands.CreateFeature;
using Gamechain.Application.Services.Features.Commands.DeleteFeature;
using Gamechain.Application.Services.Features.Commands.UpdateFeature;
using Gamechain.Application.Services.Features.Queries.GetFeatures;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gamechain.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeatureController : ControllerBase
    {
        private readonly ISender _mediator;

        public FeatureController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<List<FeatureResponse>> GetFeatures()
        {
            return _mediator.Send(new GetFeaturesQuery());
        }

        [HttpPost]
        public Task<FeatureResponse> CreateFeature([FromBody] CreateFeatureCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpPut]
        public Task<FeatureResponse> UpdateFeature([FromBody] UpdateFeatureCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpDelete("{featureId}")]
        public Task DeleteFeature(Guid featureId)
        {
            var command = new DeleteFeatureCommand(featureId);

            return _mediator.Send(command);
        }
    }
}
