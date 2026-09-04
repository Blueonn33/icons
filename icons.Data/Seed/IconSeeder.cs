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
                        UserId = "e52b120d-ef9b-4615-864e-fc21227711e6",
                        Username = "Jushiro Ukitake",
                        UserProfilePictureUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fstatic.wikia.nocookie.net%2Fbleach%2Fimages%2F5%2F5e%2FUkitake_P.Portable.png%2Frevision%2Flatest%3Fcb%3D20230128190156%26path-prefix%3Des&f=1&nofb=1&ipt=8b8a3c9e749de524c769ebc74f76827cb2c922ae27139e40da3d8795e6874485"
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
                        UserId = "7804ad0f-28f8-461d-b2b1-6e2e46f16eb7",
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