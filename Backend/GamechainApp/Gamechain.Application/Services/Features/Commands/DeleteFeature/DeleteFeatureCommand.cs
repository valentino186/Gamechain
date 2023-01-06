using MediatR;

namespace Gamechain.Application.Services.Features.Commands.DeleteFeature
{
    public record DeleteFeatureCommand(
        Guid Id) : IRequest
    {
    }
}
