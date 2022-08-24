using Gamechain.Domain.Entities.Aggregates.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamechain.Infrastructure.EntityFrameworkCore.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.FirstName)
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(32)
                .IsRequired();
        }
    }
}
