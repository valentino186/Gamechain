using Gamechain.Application.Interfaces.Repositories.Common;
using Gamechain.Domain.Entities.Aggregates.Feature;

namespace Gamechain.Application.Interfaces.Repositories
{
    public interface IFeatureRepository : IRepository<Feature>
    {
    }
}
