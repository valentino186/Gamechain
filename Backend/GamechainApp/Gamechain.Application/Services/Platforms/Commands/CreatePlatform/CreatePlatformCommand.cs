using Gamechain.Application.Common.Responses;
using MediatR;

namespace Gamechain.Application.Services.Platforms.Commands.CreatePlatform
{
    public record CreatePlatformCommand(
        string Name) : IRequest<PlatformResponse>
    {
    }
}
