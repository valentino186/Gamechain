using Gamechain.Application.Contracts.Common.Responses;
using Gamechain.Application.Contracts.Requests.Publishers;

namespace Gamechain.Application.Contracts.Interfaces.AppServices
{
    public interface IPublisherAppService
    {
        Task<List<PublisherResponse>> GetPublishers();
        Task<PublisherResponse> CreatePublisher(CreatePublisherRequest request);
    }
}
