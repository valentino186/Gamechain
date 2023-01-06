using AutoMapper;
using Gamechain.Application.Common.Responses;
using Gamechain.Application.Interfaces.Repositories;
using Gamechain.Domain.Entities.Aggregates.Feature;
using Gamechain.Domain.Exceptions;
using MediatR;

namespace Gamechain.Application.Services.Features.Commands.UpdateFeature
{
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand, FeatureResponse>
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly IMapper _mapper;

        public UpdateFeatureCommandHandler(IFeatureRepository featureRepository, IMapper mapper)
        {
            _featureRepository = featureRepository;
            _mapper = mapper;
        }


        public async Task<FeatureResponse> Handle(UpdateFeatureCommand command, CancellationToken cancellationToken)
        {
            var feature = await _featureRepository.GetById(command.Id);

            if (feature == null)
            {
                throw new EntityNotFoundException(typeof(Feature));
            }

            feature.SetName(command.Name);

            await _featureRepository.Update(feature);

            return _mapper.Map<FeatureResponse>(feature);
        }
    }
}
