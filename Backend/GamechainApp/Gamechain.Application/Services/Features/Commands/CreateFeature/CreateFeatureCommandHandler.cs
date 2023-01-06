using AutoMapper;
using Gamechain.Application.Common.Responses;
using Gamechain.Application.Interfaces.Repositories;
using Gamechain.Domain.Entities.Aggregates.Feature;
using MediatR;

namespace Gamechain.Application.Services.Features.Commands.CreateFeature
{
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand, FeatureResponse>
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly IMapper _mapper;

        public CreateFeatureCommandHandler(IFeatureRepository featureRepository, IMapper mapper)
        {
            _featureRepository = featureRepository;
            _mapper = mapper;
        }


        public async Task<FeatureResponse> Handle(CreateFeatureCommand command, CancellationToken cancellationToken)
        {
            var feature = new Feature(command.Name);

            await _featureRepository.Create(feature);

            return _mapper.Map<FeatureResponse>(feature);
        }
    }
}
