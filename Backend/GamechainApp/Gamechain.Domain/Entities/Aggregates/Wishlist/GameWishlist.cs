﻿using Gamechain.Domain.Entities.Common;

namespace Gamechain.Domain.Entities.Aggregates.Wishlist
{
    public class GameWishlist : Entity
    {
        public Guid GameId { get; set; }
        public Guid WishlistId { get; set; }
    }
}
