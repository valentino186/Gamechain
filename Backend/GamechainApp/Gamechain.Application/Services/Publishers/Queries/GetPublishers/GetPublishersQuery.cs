using Gamechain.Application.Contracts.Common.Responses;
using MediatR;

namespace Gamechain.Application.Services.Publishers.Queries.GetPublishers
{
    public record GetPublishersQuery : IRequest<List<PublisherResponse>>;
}
