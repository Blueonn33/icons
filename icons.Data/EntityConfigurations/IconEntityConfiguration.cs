using icons.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace icons.Data.EntityConfigurations
{
    public class IconEntityConfiguration : IEntityTypeConfiguration<Icon>
    {
        public void Configure(EntityTypeBuilder<Icon> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.AverageRating)
                .HasPrecision(2, 1);
        }
    }
}
