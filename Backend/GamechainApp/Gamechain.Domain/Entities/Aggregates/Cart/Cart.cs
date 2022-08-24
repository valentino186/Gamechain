using Gamechain.Domain.Entities.Common;

namespace Gamechain.Domain.Entities.Aggregates.Cart
{
    public class Cart : AggregateRoot
    {
        public Guid UserId { get; set; }
        public IList<GameCart> Games { get; set; }

        public Cart(Guid userId)
        {
            UserId = userId;

            Games = new List<GameCart>();
        }

        public Cart(Guid id, Guid userId) : this(userId)
        {
            Id = id;
        }
    }
}
