using Gamechain.Application.Common.Responses;
using MediatR;

namespace Gamechain.Application.Services.Platforms.Queries.GetPlatforms
{
    public record GetPlatformsQuery : IRequest<List<PlatformResponse>>
    {
    }
}
