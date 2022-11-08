using Gamechain.Application.Contracts.Common.Responses;
using MediatR;

namespace Gamechain.Application.Services.Publishers.Commands.UpdatePublisher
{
    public record UpdatePublisherCommand(
        Guid Id,
        string Name) : IRequest<PublisherResponse>
    {
    }
}
