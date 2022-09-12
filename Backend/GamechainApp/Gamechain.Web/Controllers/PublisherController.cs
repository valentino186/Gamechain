using Gamechain.Application.Contracts.Common.Responses;
using Gamechain.Application.Contracts.Interfaces.AppServices;
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

        [HttpGet("{id}")]
        public Task<PublisherResponse> GetPublisherById(Guid id)
        {
            return _publisherAppService.GetPublisherById(id);
        }
    }
}
