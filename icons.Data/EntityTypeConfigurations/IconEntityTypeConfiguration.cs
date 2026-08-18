using icons.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace icons.Data.EntityConfigurations
{
    public class IconEntityTypeConfiguration : IEntityTypeConfiguration<Icon>
    {
        public void Configure(EntityTypeBuilder<Icon> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.AverageRating)
                .HasPrecision(2, 1);

            builder.HasData(
                new Icon
                {
                    Id = 1,
                    AverageRating = 4.5m,
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    ImageUrl =
                        "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse1.mm.bing.net%2Fth%2Fid%2FOIP.91eYh0AoL30hoWPLfFJLcgHaHa%3Fpid%3DApi&f=1&ipt=c61fcc07795dd063b844aa7d68f63b753b63ed2c1742d4ad313b8ab12242ff99",
                    Title = "Car",
                    UserId = "user-seed-1",
                    Username = "Sapphire"
                },
                new Icon
                {
                    Id = 2,
                    AverageRating = 4.7m,
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ImageUrl =
                        "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fitechgroups.co.uk%2Fwp-content%2Fuploads%2F2025%2F10%2Fphone-icon-telephone-icon-symbol-for-app-and-messenger-vector-768x768.jpg&f=1&nofb=1&ipt=9f1c9ddf32423859781ea4f5c2f501ef9f08c1e07c26309cad48d5caba9837ac",
                    Title = "Phone",
                    UserId = "user-seed-2",
                    Username = "Indigo"
                }
            );
        }
    }
}
