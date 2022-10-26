using MediatR;

namespace Gamechain.Application.Services.Publishers.Commands.DeletePublisher
{
    public record DeletePublisherCommand(
        Guid Id) : IRequest
    {
    }
}
