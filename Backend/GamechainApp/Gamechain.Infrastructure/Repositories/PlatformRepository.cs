using Gamechain.Application.Interfaces.Repositories;
using Gamechain.Domain.Entities.Aggregates.Platform;
using Gamechain.Infrastructure.EntityFrameworkCore.Context;
using Gamechain.Infrastructure.Repositories.Common;

namespace Gamechain.Infrastructure.Repositories
{
    public class PlatformRepository : BaseRepository<Platform>, IPlatformRepository
    {
        public PlatformRepository(GamechainDbContext context) : base(context)
        {
        }
    }
}
