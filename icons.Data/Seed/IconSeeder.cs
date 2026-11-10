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
                        PublishedTime = new DateTime(2026, 8, 10),
                        AverageRating = 4,
                        Description =
                            "Marin's mother died when she was very young, leaving her under the care of her father. Although he loves her, Marin's father is often called to work abroad, leaving her to live alone most days. Prior to the start of the series, Marin secured a part-time job as an amateur model.",
                        ImageUrl =
                            "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdn.hipwallpaper.com%2Fthumbnail%2F612%2FKitagawa-Marin-4k-UHD-Wallpaper-1.jpg&f=1&nofb=1&ipt=8267cbfb289f082395ddab247c2e4e31130b758cc17e19f3cbabbeb8833806d6&ipo=images",
                        Title = "Marin Kitagawa",
                        UserId = "cb5d1652-65c2-4990-b240-f6a3ce1e4a18",
                        Username = "icons_admin😎",
                        UserProfilePictureUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdn.pfps.gg%2Fpfps%2F3724-byakuya-kuchiki-profile-icon.png&f=1&nofb=1&ipt=1beed75c5a39ad22460afe00100ca77025d4732b11d0375487bfd71fd09d8907"
                    },
                    new Icon
                    {
                        PublishedTime = new DateTime(2026, 9, 2),
                        AverageRating = 5,
                        Description =
                            "As a result of his early childhood years, Levi is described as a \"clean freak\" by those who know him personally as he prefers his environment and himself to be spotlessly clean. He is averse to having either himself or his equipment soiled, and has been known to wipe down his blood-smeared blades while still on the battlefield. However, he will not hesitate to touch filth if he deems it necessary.",
                        ImageUrl =
                            "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fblogger.googleusercontent.com%2Fimg%2Fa%2FAVvXsEjJW5OakGV-n8ZW0VtCKVNYdg5YFJ0zunuURgrj9zX8BG76jFjRo1YagxXnjZRFleRVDks5tNQ2baqVh5UviLLZnqMZ4qysy3ROdapOm_RKn4CpFXjbvSPVDLNgdT4pwXof2BE2w3TbCo5tyt0mr3Vta9iVWA4VWIXSuWpNQiFSSv1dxY_NguHOT5uuX6Qp%3Ds16000&f=1&nofb=1&ipt=642be5b0e276ac5279ec56ac2e01e70a90be00d23d8bb0e1760a63f06b214e55&ipo=images",
                        Title = "Levi Ackerman",
                        UserId = "18d96ab2-c4b3-4f7f-9af5-735e9dbcd348",
                        Username = "Levi Ackerman",
                        UserProfilePictureUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi.pinimg.com%2F736x%2F8f%2F92%2F15%2F8f9215e40b0b0b45f8182b38a77f6403.jpg&f=1&nofb=1&ipt=33f4de0e68bcd16ace61b4b2179a8fc9702416e8009ff30d59eb95b93a137243&ipo=images"
                    },
                    new Icon
                    {
                        PublishedTime = new DateTime(2026, 9, 1),
                        AverageRating = 0,
                        Description =
                            "Orihime is independent, friendly, humorous, optimistic, sensitive, caring and kind. She comes off as naive and rather clueless, which contradicts her exceptionally high marks as third highest in her grade. She studies hard because when her grades drop, she receives less financial support from her relatives.",
                        ImageUrl =
                            "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdn.polyspeak.ai%2Fspeakmaster%2Fd58f8905eb22280c2bc38fe4c44b2354.webp&f=1&nofb=1&ipt=85dd9ce25e9e4491e76422659ec08ac1944fe3df30da9799a17cf17b20b81db3",
                        Title = "Orihime Inoue",
                        UserId = "fca0ea4c-bc91-4d6d-8c95-f1ef4e3d71e6",
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