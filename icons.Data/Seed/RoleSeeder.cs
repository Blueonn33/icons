using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace icons.Data.Seed
{
    public class RoleSeeder
    {
        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync(Constants.Roles.Admin))
            {
                var adminRole = new IdentityRole(Constants.Roles.Admin);
                await roleManager.CreateAsync(adminRole);
            }
        }
    }
}
