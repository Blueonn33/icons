using icons.Data.Enums;
using icons.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace icons.Data.Seed
{
    public class ReviewSeeder
    {
        public static async Task SeedReviewsAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            if (!await context.Reviews.AnyAsync())
            {
                var reviews = new List<Review>
                {
                    new Review
                    {
                        Title = "Nice",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                        Rating = EnumReviewRating.VeryGood,
                        PublishedTime = new DateTime(2026, 8, 25),
                        IconId = 4,
                        UserId = "4860fe91-0fd6-4ef5-b829-266a738b9820",
                        Username = "Jushiro Ukitake",
                        UserProfilePictureUrl =
                            "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fstatic.wikia.nocookie.net%2Fbleach%2Fimages%2F5%2F5e%2FUkitake_P.Portable.png%2Frevision%2Flatest%3Fcb%3D20230128190156%26path-prefix%3Des&f=1&nofb=1&ipt=8b8a3c9e749de524c769ebc74f76827cb2c922ae27139e40da3d8795e6874485"
                    },
                    new Review
                    {
                        Title = "OK👍",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        Rating = EnumReviewRating.Excellent,
                        PublishedTime = new DateTime(2026, 7, 11),
                        IconId = 5,
                        UserId = "9653bbf6-5fc8-42a2-aab8-d8cf7dbe70b1",
                        Username = "Byakuya Kuchiki",
                        UserProfilePictureUrl =
                            "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fitechgroups.co.uk%2Fwp-content%2Fuploads%2F2025%2F10%2Fphone-icon-telephone-icon-symbol-for-app-and-messenger-vector-768x768.jpg&f=1&nofb=1&ipt=9f1c9ddf32423859781ea4f5c2f501ef9f08c1e07c26309cad48d5caba9837ac",

                    }
                };

                await context.Reviews.AddRangeAsync(reviews);
                await context.SaveChangesAsync();
            }
        }
    }
}
