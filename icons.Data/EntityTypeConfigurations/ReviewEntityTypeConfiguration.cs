using icons.Data.Enums;
using icons.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace icons.Data.EntityTypeConfigurations
{
    public class ReviewEntityTypeConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasData(
                new Review
                {
                    Id = 1,
                    Title = "Nice",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Rating = EnumReviewRating.VeryGood,
                    IconId = 1,
                    UserId = "user-seed-1",
                    Username = "Sapphire",
                    UserProfilePictureUrl =
                        "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fstatic.wikia.nocookie.net%2Fbleach%2Fimages%2F5%2F5e%2FUkitake_P.Portable.png%2Frevision%2Flatest%3Fcb%3D20230128190156%26path-prefix%3Des&f=1&nofb=1&ipt=8b8a3c9e749de524c769ebc74f76827cb2c922ae27139e40da3d8795e6874485",

                },
                new Review
                {
                    Id = 2,
                    Title = "OK👍",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                    Rating = EnumReviewRating.Excellent,
                    IconId = 2,
                    UserId = "user-seed-2",
                    Username = "Indigo",
                    UserProfilePictureUrl =
                        "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fitechgroups.co.uk%2Fwp-content%2Fuploads%2F2025%2F10%2Fphone-icon-telephone-icon-symbol-for-app-and-messenger-vector-768x768.jpg&f=1&nofb=1&ipt=9f1c9ddf32423859781ea4f5c2f501ef9f08c1e07c26309cad48d5caba9837ac",

                }
            );
        }
    }
}
