using Gamechain.Application.Interfaces.Repositories;
using Gamechain.Domain.Entities.Aggregates.Game;
using Gamechain.Infrastructure.EntityFrameworkCore.Context;
using Gamechain.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace Gamechain.Infrastructure.Repositories
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(GamechainDbContext context) : base(context)
        {
        }

        public Task<List<Game>> GetPublisherGames(Guid publisherId)
        {
            var games = _dbSet.Where(x => x.PublisherId == publisherId)
                .Include(x => x.Features)
                .Include(x => x.Genres)
                .Include(x => x.Platforms)
                .ToListAsync();

            return games;
        }
    }
}
