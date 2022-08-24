using Gamechain.Domain.Entities.Aggregates.Game;
using Gamechain.Domain.Entities.Aggregates.Genre;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamechain.Infrastructure.EntityFrameworkCore.Configurations
{
    public class GameGenreConfiguration : IEntityTypeConfiguration<GameGenre>
    {
        public void Configure(EntityTypeBuilder<GameGenre> builder)
        {
            builder.ToTable("GameGenre");

            builder.HasKey(x => new { x.GameId, x.GenreId });

            builder.HasOne<Game>()
                .WithMany(x => x.Genres)
                .HasForeignKey(x => x.GameId);

            builder.HasOne<Genre>()
                .WithMany()
                .HasForeignKey(x => x.GenreId);
        }
    }
}
