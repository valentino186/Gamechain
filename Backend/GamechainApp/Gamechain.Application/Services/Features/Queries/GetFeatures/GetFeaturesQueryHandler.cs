using AutoMapper;
using Gamechain.Application.Common.Responses;
using Gamechain.Application.Interfaces.Repositories;
using MediatR;

namespace Gamechain.Application.Services.Features.Queries.GetFeatures
{
    public class GetFeaturesQueryHandler : IRequestHandler<GetFeaturesQuery, List<FeatureResponse>>
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly IMapper _mapper;

        public GetFeaturesQueryHandler(IFeatureRepository featureRepository, IMapper mapper)
        {
            _featureRepository = featureRepository;
            _mapper = mapper;
        }

        public async Task<List<FeatureResponse>> Handle(GetFeaturesQuery request, CancellationToken cancellationToken)
        {
            var features = await _featureRepository.GetAll();

            return _mapper.Map<List<FeatureResponse>>(features);
        }
    }
}
