using Gamechain.Application.Common.Responses;
using MediatR;

namespace Gamechain.Application.Services.Publishers.Commands.CreatePublisher
{
    public record CreatePublisherCommand(
        string Name) : IRequest<PublisherResponse>;
}
