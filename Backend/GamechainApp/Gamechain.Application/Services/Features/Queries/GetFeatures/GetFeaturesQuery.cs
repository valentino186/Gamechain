using Gamechain.Application.Common.Responses;
using MediatR;

namespace Gamechain.Application.Services.Features.Queries.GetFeatures
{
    public record GetFeaturesQuery : IRequest<List<FeatureResponse>>
    {
    }
}
