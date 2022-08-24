using Gamechain.Domain.Entities.Aggregates.Game;
using Gamechain.Domain.Entities.Aggregates.Publisher;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamechain.Infrastructure.EntityFrameworkCore.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Games", x => x.IsTemporal());

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(512)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.Discount)
                .IsRequired();

            builder.HasOne<Publisher>()
                .WithMany()
                .HasForeignKey(x => x.PublisherId);
        }
    }
}
