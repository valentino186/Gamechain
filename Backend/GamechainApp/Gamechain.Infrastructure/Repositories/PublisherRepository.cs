using Gamechain.Application.Contracts.Interfaces.Repositories;
using Gamechain.Domain.Entities.Aggregates.Publisher;
using Gamechain.Infrastructure.EntityFrameworkCore.Context;

namespace Gamechain.Infrastructure.Repositories
{
    public class PublisherRepository : BaseRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(GamechainDbContext context) : base(context)
        {
        }
    }
}
