using Gamechain.Application.Interfaces.Repositories;
using Gamechain.Domain.Entities.Aggregates.Publisher;
using Gamechain.Infrastructure.EntityFrameworkCore.Context;
using Gamechain.Infrastructure.Repositories.Common;

namespace Gamechain.Infrastructure.Repositories
{
    public class PublisherRepository : BaseRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(GamechainDbContext context) : base(context)
        {
        }
    }
}
