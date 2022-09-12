using Gamechain.Application.Contracts.Common.Responses;

namespace Gamechain.Application.Contracts.Interfaces.AppServices
{
    public interface IPublisherAppService
    {
        Task<List<PublisherResponse>> GetPublishers();
        Task<PublisherResponse> GetPublisherById(Guid publisherId);
    }
}
