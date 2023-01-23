using Gamechain.Application.Common.Responses;
using MediatR;

namespace Gamechain.Application.Services.Features.Commands.CreateFeature
{
    public record CreateFeatureCommand(
        string Name) : IRequest<FeatureResponse>
    {
    }
}
