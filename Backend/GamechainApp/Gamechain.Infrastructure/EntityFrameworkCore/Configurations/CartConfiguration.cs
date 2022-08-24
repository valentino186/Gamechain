using Gamechain.Domain.Entities.Aggregates.Cart;
using Gamechain.Domain.Entities.Aggregates.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamechain.Infrastructure.EntityFrameworkCore.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");

            builder.HasKey(x => x.Id);

            builder.HasOne<ApplicationUser>()
                .WithOne()
                .HasForeignKey<Cart>(x => x.UserId);
        }
    }
}
