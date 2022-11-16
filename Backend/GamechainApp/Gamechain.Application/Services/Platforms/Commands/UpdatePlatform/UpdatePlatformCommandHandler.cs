using AutoMapper;
using Gamechain.Application.Common.Responses;
using Gamechain.Application.Interfaces.Repositories;
using Gamechain.Domain.Entities.Aggregates.Platform;
using Gamechain.Domain.Exceptions;
using MediatR;

namespace Gamechain.Application.Services.Platforms.Commands.UpdatePlatform
{
    public class UpdatePlatformCommandHandler : IRequestHandler<UpdatePlatformCommand, PlatformResponse>
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;

        public UpdatePlatformCommandHandler(IPlatformRepository platformRepository, IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
        }

        public async Task<PlatformResponse> Handle(UpdatePlatformCommand command, CancellationToken cancellationToken)
        {
            var platform = await _platformRepository.GetById(command.Id);

            if (platform == null)
            {
                throw new EntityNotFoundException(typeof(Platform));
            }

            _mapper.Map(command, platform);

            await _platformRepository.Update(platform);

            return _mapper.Map<PlatformResponse>(platform);
        }
    }
}
