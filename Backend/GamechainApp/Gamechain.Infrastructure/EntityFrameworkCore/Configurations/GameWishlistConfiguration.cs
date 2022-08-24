using Gamechain.Domain.Entities.Aggregates.Game;
using Gamechain.Domain.Entities.Aggregates.Wishlist;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamechain.Infrastructure.EntityFrameworkCore.Configurations
{
    public class GameWishlistConfiguration : IEntityTypeConfiguration<GameWishlist>
    {
        public void Configure(EntityTypeBuilder<GameWishlist> builder)
        {
            builder.ToTable("GameWishlist");

            builder.HasKey(x => new { x.GameId, x.WishlistId });

            builder.HasOne<Game>()
                .WithMany()
                .HasForeignKey(x => x.GameId);

            builder.HasOne<Wishlist>()
                .WithMany(x => x.Games)
                .HasForeignKey(x => x.WishlistId);
        }
    }
}
