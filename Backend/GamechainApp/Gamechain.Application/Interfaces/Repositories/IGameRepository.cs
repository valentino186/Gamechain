using Gamechain.Application.Interfaces.Repositories.Common;
using Gamechain.Domain.Entities.Aggregates.Game;

namespace Gamechain.Application.Interfaces.Repositories
{
    public interface IGameRepository : IRepository<Game>
    {
        Task<List<Game>> GetPublisherGames(Guid publisherId);
    }
}
