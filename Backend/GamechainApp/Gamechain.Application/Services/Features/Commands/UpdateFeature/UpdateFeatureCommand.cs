using Gamechain.Application.Common.Responses;
using MediatR;

namespace Gamechain.Application.Services.Features.Commands.UpdateFeature
{
    public record UpdateFeatureCommand(
        Guid Id,
        string Name) : IRequest<FeatureResponse>
    {
    }
}
