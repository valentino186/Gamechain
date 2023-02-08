using Gamechain.Application.Common.Responses;
using MediatR;

namespace Gamechain.Application.Services.Publishers.Queries.GetPublisher
{
    public record GetPublisherQuery(
        Guid Id) : IRequest<PublisherResponse>
    {
    }
}
