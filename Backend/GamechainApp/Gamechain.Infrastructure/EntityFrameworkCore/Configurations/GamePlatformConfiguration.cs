using Gamechain.Domain.Entities.Aggregates.Game;
using Gamechain.Domain.Entities.Aggregates.Platform;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamechain.Infrastructure.EntityFrameworkCore.Configurations
{
    public class GamePlatformConfiguration : IEntityTypeConfiguration<GamePlatform>
    {
        public void Configure(EntityTypeBuilder<GamePlatform> builder)
        {
            builder.ToTable("GamePlatform");

            builder.HasKey(x => new { x.GameId, x.PlatformId });

            builder.HasOne<Game>()
                .WithMany(x => x.Platforms)
                .HasForeignKey(x => x.GameId);

            builder.HasOne<Platform>()
                .WithMany()
                .HasForeignKey(x => x.PlatformId);
        }
    }
}
