using Gamechain.Application.Interfaces.Repositories;
using Gamechain.Domain.Entities.Aggregates.Feature;
using Gamechain.Domain.Exceptions;
using MediatR;

namespace Gamechain.Application.Services.Features.Commands.DeleteFeature
{
    public class DeleteFeatureCommandHandler : IRequestHandler<DeleteFeatureCommand>
    {
        private readonly IFeatureRepository _featureRepository;

        public DeleteFeatureCommandHandler(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task<Unit> Handle(DeleteFeatureCommand command, CancellationToken cancellationToken)
        {
            var feature = await _featureRepository.GetById(command.Id);

            if (feature == null)
            {
                throw new EntityNotFoundException(typeof(Feature));
            }

            await _featureRepository.Delete(feature);

            return Unit.Value;
        }
    }
}
