using Gamechain.Domain.Entities.Aggregates.Feature;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamechain.Infrastructure.EntityFrameworkCore.Configurations
{
    public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.ToTable("Features");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(32)
                .IsRequired();
        }
    }
}
