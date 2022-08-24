using Gamechain.Domain.Entities.Aggregates.Game;
using Gamechain.Domain.Entities.Aggregates.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamechain.Infrastructure.EntityFrameworkCore.Configurations
{
    public class PurschaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Purchases");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PurchaseDate)
                .IsRequired();

            builder.HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(x => x.UserId);

            builder.HasOne<Game>()
                .WithMany()
                .HasForeignKey(x => x.GameId);
        }
    }
}
