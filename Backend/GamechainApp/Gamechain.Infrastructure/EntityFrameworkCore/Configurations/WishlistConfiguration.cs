using Gamechain.Domain.Entities.Aggregates.User;
using Gamechain.Domain.Entities.Aggregates.Wishlist;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamechain.Infrastructure.EntityFrameworkCore.Configurations
{
    public class WishlistConfiguration : IEntityTypeConfiguration<Wishlist>
    {
        public void Configure(EntityTypeBuilder<Wishlist> builder)
        {
            builder.ToTable("Wishlists");

            builder.HasKey(x => x.Id);

            builder.HasOne<ApplicationUser>()
                .WithOne()
                .HasForeignKey<Wishlist>(x => x.UserId);
        }
    }
}
