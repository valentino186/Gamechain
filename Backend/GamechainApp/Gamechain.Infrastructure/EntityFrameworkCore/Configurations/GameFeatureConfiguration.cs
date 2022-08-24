using Gamechain.Domain.Entities.Aggregates.Feature;
using Gamechain.Domain.Entities.Aggregates.Game;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamechain.Infrastructure.EntityFrameworkCore.Configurations
{
    public class GameFeatureConfiguration : IEntityTypeConfiguration<GameFeature>
    {
        public void Configure(EntityTypeBuilder<GameFeature> builder)
        {
            builder.ToTable("GameFeature");

            builder.HasKey(x => new { x.GameId, x.FeatureId });

            builder.HasOne<Game>()
                .WithMany(x => x.Features)
                .HasForeignKey(x => x.GameId);

            builder.HasOne<Feature>()
                .WithMany()
                .HasForeignKey(x => x.FeatureId);
        }
    }
}
