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
                        UserId = "ENTER_USER_ID",
                        Username = "Jushiro Ukitake",
                        UserProfilePictureUrl =
                            "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fimages-wixmp-ed30a86b8c4ca887773594c2.wixmp.com%2Fi%2F1b75e5cf-332b-48f1-a8fa-a7dd279deef9%2Fdadyw2o-761b1f04-995a-422d-acc3-905fe4ea7f39.png%2Fv1%2Ffill%2Fw_748%2Ch_476%2Cq_80%2Cstrp%2Ftwo__jushiro_ukitake_x_reader__bleach__by_truth4sanity_dadyw2o-fullview.jpg&f=1&nofb=1&ipt=a3ca84031f93347162a224fd1575cdb8a98f0d71c2f179bef4b407155f8952a9"
                    },
                    new Review
                    {
                        Title = "OK👍",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        Rating = EnumReviewRating.Excellent,
                        PublishedTime = new DateTime(2026, 7, 11),
                        IconId = 2,
                        UserId = "ENTER_USER_ID",
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
