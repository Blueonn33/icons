using icons.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace icons.Data.Seed
{
    public class IconSeeder
    {
        public static async Task SeedIconsAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            if (!await context.Icons.AnyAsync())
            {
                var icons = new List<Icon>
                {
                    new Icon
                    {
                        PublishedTime = new DateTime(2026, 9, 2),
                        AverageRating = 4.5,
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                        ImageUrl =
                            "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdn.pfps.gg%2Fpfps%2F4476-ichigo-kurosaki-profile-picture.png&f=1&nofb=1&ipt=7f770419003930f526f3ad713588eaaeec3057d45cc43cb6ca0296025f2699cd",
                        Title = "Ichigo Kurosaki",
                        UserId = "ENTER_USER_ID",
                        Username = "Jushiro Ukitake",
                        UserProfilePictureUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fimages-wixmp-ed30a86b8c4ca887773594c2.wixmp.com%2Fi%2F1b75e5cf-332b-48f1-a8fa-a7dd279deef9%2Fdadyw2o-761b1f04-995a-422d-acc3-905fe4ea7f39.png%2Fv1%2Ffill%2Fw_748%2Ch_476%2Cq_80%2Cstrp%2Ftwo__jushiro_ukitake_x_reader__bleach__by_truth4sanity_dadyw2o-fullview.jpg&f=1&nofb=1&ipt=a3ca84031f93347162a224fd1575cdb8a98f0d71c2f179bef4b407155f8952a9"
                    },
                    new Icon
                    {
                        PublishedTime = new DateTime(2026, 9, 1),
                        AverageRating = 4.7,
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        ImageUrl =
                            "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdn.polyspeak.ai%2Fspeakmaster%2Fd58f8905eb22280c2bc38fe4c44b2354.webp&f=1&nofb=1&ipt=85dd9ce25e9e4491e76422659ec08ac1944fe3df30da9799a17cf17b20b81db3",
                        Title = "Orihime Inoue",
                        UserId = "ENTER_USER_ID",
                        Username = "Byakuya Kuchiki",
                        UserProfilePictureUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdn.pfps.gg%2Fpfps%2F5623-byakuya-kuchiki-profile-image.png&f=1&nofb=1&ipt=64ca4562e078e950da79e8feb4bd67ff9476530892e91f410071a7110c490556"
                    }
                };

                await context.Icons.AddRangeAsync(icons);
                await context.SaveChangesAsync();
            }
        }
    }
}