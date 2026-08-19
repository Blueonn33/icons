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
                        AverageRating = 4.5m,
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                        ImageUrl =
                            "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse1.mm.bing.net%2Fth%2Fid%2FOIP.91eYh0AoL30hoWPLfFJLcgHaHa%3Fpid%3DApi&f=1&ipt=c61fcc07795dd063b844aa7d68f63b753b63ed2c1742d4ad313b8ab12242ff99",
                        Title = "Car",
                        UserId = "10981ce8-9e80-4156-8afe-731efa65691b",
                        Username = "Jushiro Ukitake"
                    },
                    new Icon
                    {
                        AverageRating = 4.7m,
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        ImageUrl =
                            "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fitechgroups.co.uk%2Fwp-content%2Fuploads%2F2025%2F10%2Fphone-icon-telephone-icon-symbol-for-app-and-messenger-vector-768x768.jpg&f=1&nofb=1&ipt=9f1c9ddf32423859781ea4f5c2f501ef9f08c1e07c26309cad48d5caba9837ac",
                        Title = "Phone",
                        UserId = "267d5b8b-6ba8-4c04-aa40-a11b727167d9",
                        Username = "Byakuya Kuchiki"
                    }
                };

                await context.Icons.AddRangeAsync(icons);
                await context.SaveChangesAsync();
            }
        }
    }
}