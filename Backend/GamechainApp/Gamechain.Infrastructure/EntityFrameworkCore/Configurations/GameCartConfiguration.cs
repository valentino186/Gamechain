using Gamechain.Domain.Entities.Aggregates.Cart;
using Gamechain.Domain.Entities.Aggregates.Game;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamechain.Infrastructure.EntityFrameworkCore.Configurations
{
    public class GameCartConfiguration : IEntityTypeConfiguration<GameCart>
    {
        public void Configure(EntityTypeBuilder<GameCart> builder)
        {
            builder.ToTable("GameCart");

            builder.HasKey(x => new { x.GameId, x.CartId });

            builder.HasOne<Game>()
                .WithMany()
                .HasForeignKey(x => x.GameId);

            builder.HasOne<Cart>()
                .WithMany(x => x.Games)
                .HasForeignKey(x => x.CartId);
        }
    }
}
