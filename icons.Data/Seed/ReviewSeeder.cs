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
                        IconId = 1,
                        UserId = "18d96ab2-c4b3-4f7f-9af5-735e9dbcd348",
                        Username = "Levi Ackerman",
                        UserProfilePictureUrl =
                            "https://aniyuki.com/wp-content/uploads/2025/03/aniyuki-Levi-Ackerman-avatar-15.jpg"
                    },
                    new Review
                    {
                        Title = "OK👍",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        Rating = EnumReviewRating.Excellent,
                        PublishedTime = new DateTime(2026, 7, 11),
                        IconId = 2,
                        UserId = "fca0ea4c-bc91-4d6d-8c95-f1ef4e3d71e6",
                        Username = "Byakuya Kuchiki",
                        UserProfilePictureUrl =
                            "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdn.pfps.gg%2Fpfps%2F5623-byakuya-kuchiki-profile-image.png&f=1&nofb=1&ipt=64ca4562e078e950da79e8feb4bd67ff9476530892e91f410071a7110c490556",

                    }
                };

                await context.Reviews.AddRangeAsync(reviews);
                await context.SaveChangesAsync();
            }
        }
    }
}
