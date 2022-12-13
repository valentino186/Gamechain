using AutoMapper;
using Gamechain.Application.Common.Responses;
using Gamechain.Application.Interfaces.Repositories;
using Gamechain.Domain.Entities.Aggregates.Platform;
using MediatR;

namespace Gamechain.Application.Services.Platforms.Commands.CreatePlatform
{
    public class CreatePlatformCommandHandler : IRequestHandler<CreatePlatformCommand, PlatformResponse>
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;

        public CreatePlatformCommandHandler(IPlatformRepository platformRepository, IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
        }

        public async Task<PlatformResponse> Handle(CreatePlatformCommand command, CancellationToken cancellationToken)
        {
            var platform = _mapper.Map<Platform>(command);

            await _platformRepository.Create(platform);

            return _mapper.Map<PlatformResponse>(platform);
        }
    }
}
