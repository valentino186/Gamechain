using AutoMapper;
using Gamechain.Application.Common.Responses;
using Gamechain.Domain.Entities.Aggregates.Feature;

namespace Gamechain.Application.Profiles
{
    public class FeatureProfile : Profile
    {
        public FeatureProfile()
        {
            CreateMap<Feature, FeatureResponse>();
        }
    }
}
