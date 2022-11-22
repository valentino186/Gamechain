using MediatR;

namespace Gamechain.Application.Services.Platforms.Commands.DeletePlatform
{
    public record DeletePlatformCommand(
        Guid Id) : IRequest
    {
    }
}
