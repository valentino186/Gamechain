using Gamechain.Domain.Entities.Aggregates.Genre;
using Gamechain.Infrastructure.EntityFrameworkCore.Context;
using Gamechain.Infrastructure.Repositories.Common;

namespace Gamechain.Infrastructure.Repositories
{
    public class GenreRepository : BaseRepository<Genre>
    {
        public GenreRepository(GamechainDbContext context) : base(context)
        {
        }
    }
}
