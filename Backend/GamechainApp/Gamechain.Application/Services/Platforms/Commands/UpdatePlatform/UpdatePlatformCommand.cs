using Gamechain.Application.Common.Responses;
using MediatR;

namespace Gamechain.Application.Services.Platforms.Commands.UpdatePlatform
{
    public record UpdatePlatformCommand(
        Guid Id,
        string Name) : IRequest<PlatformResponse>
    {
    }
}
