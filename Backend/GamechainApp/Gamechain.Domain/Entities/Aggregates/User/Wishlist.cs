using Gamechain.Domain.Entities.Common;

namespace Gamechain.Domain.Entities.Aggregates.User
{
    public class Wishlist : Entity
    {
        public Guid UserId { get; set; }
        public IList<GameWishlist> Games { get; set; }

        public Wishlist(Guid userId)
        {
            UserId = userId;
            Games = new List<GameWishlist>();
        }

        public Wishlist(Guid id, Guid userId) : this(userId)
        {
            Id = id;
        }
    }
}
