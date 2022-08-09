using Gamechain.Domain.Entities.Common;

namespace Gamechain.Domain.Entities.Aggregates.User
{
    public class Wishlist : Entity
    {
        public Guid UserId { get; set; }
        public IList<GameWishlist> Games { get; set; }
    }
}
