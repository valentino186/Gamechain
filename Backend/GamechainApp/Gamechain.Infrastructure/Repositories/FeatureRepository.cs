using Gamechain.Application.Interfaces.Repositories;
using Gamechain.Domain.Entities.Aggregates.Feature;
using Gamechain.Infrastructure.EntityFrameworkCore.Context;
using Gamechain.Infrastructure.Repositories.Common;

namespace Gamechain.Infrastructure.Repositories
{
    public class FeatureRepository : BaseRepository<Feature>, IFeatureRepository
    {
        public FeatureRepository(GamechainDbContext context): base(context)
        {
        }
    }
}
