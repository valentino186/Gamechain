using Gamechain.Application.Contracts.Common.Responses;
using Gamechain.Application.Contracts.Interfaces.AppServices;
using Gamechain.Application.Contracts.Requests.Publishers;
using Microsoft.AspNetCore.Mvc;

namespace Gamechain.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherAppService _publisherAppService;

        public PublisherController(IPublisherAppService publisherAppService)
        {
            _publisherAppService = publisherAppService;
        }

        [HttpGet]
        public Task<List<PublisherResponse>> GetPublishers()
        {
            return _publisherAppService.GetPublishers();
        }

        [HttpPost]
        public Task<PublisherResponse> CreatePublisher([FromBody] CreatePublisherRequest request)
        {
            return _publisherAppService.CreatePublisher(request);
        }
    }
}
