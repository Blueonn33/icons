using icons.Data.Constants;
using icons.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace icons.Data.Seed
{
    public class UserSeeder
    {
        public static async Task SeedUsersAsync(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var adminEmail = configuration["AdminUser:Email"];
            var adminPassword = configuration["AdminUser:Password"];
            var adminName = configuration["AdminUser:Name"];
            var adminProfilePictureUrl = configuration["AdminUser:ProfilePictureUrl"];
            var adminElixir = configuration["AdminUser:Elixir"];
            var adminRank = configuration["Admin:Rank"];

            await CreateUserWithRole(userManager, adminEmail, adminPassword, adminName, adminProfilePictureUrl, adminElixir, adminRank,
                Roles.Admin);
        }

        public static async Task CreateUserWithRole(UserManager<ApplicationUser> userManager, string email,
            string password, string name, string profilePictureUrl, string elixir, string rank, string role)
        {
            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = email,
                    NormalizedEmail = email.ToUpper(),
                    EmailConfirmed = true,
                    UserName = email,
                    NormalizedUserName = email.ToUpper(),
                    Name = name,
                    ProfilePictureUrl = profilePictureUrl,
                    IsDeleted = false,
                    Elixir = int.Parse(elixir),
                    Rank = Enum.Parse<EnumUserElixirRank>(rank)
                };

                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
                else
                {
                    throw new Exception(
                        $"There was a problem creating a user with email: {email}. Errors: {string.Join(", ", result.Errors)}");
                }
            }
        }
    }
}
