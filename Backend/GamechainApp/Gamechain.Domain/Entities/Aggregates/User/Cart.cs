using Gamechain.Domain.Entities.Common;

namespace Gamechain.Domain.Entities.Aggregates.User
{
    public class Cart : Entity
    {
        public Guid UserId { get; set; }
        public IList<GameCart> Games { get; set; }
    }
}
