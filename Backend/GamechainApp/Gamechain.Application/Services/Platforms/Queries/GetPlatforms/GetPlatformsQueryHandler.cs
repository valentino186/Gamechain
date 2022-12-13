using AutoMapper;
using Gamechain.Application.Common.Responses;
using Gamechain.Application.Interfaces.Repositories;
using MediatR;

namespace Gamechain.Application.Services.Platforms.Queries.GetPlatforms
{
    public class GetPlatformsQueryHandler : IRequestHandler<GetPlatformsQuery, List<PlatformResponse>>
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;

        public GetPlatformsQueryHandler(IPlatformRepository platformRepository, IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
        }

        public async Task<List<PlatformResponse>> Handle(GetPlatformsQuery query, CancellationToken cancellationToken)
        {
            var platforms = await _platformRepository.GetAll();

            return _mapper.Map<List<PlatformResponse>>(platforms);
        }
    }
}
