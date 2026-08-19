using icons.Data.Constants;
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

            var user1Email = configuration["SeedUser1:Email"];
            var user1Password = configuration["SeedUser1:Password"];
            var user1Name = configuration["SeedUser1:Name"];
            var user1ProfilePictureUrl = configuration["SeedUser1:ProfilePictureUrl"];

            var user2Email = configuration["SeedUser2:Email"];
            var user2Password = configuration["SeedUser2:Password"];
            var user2Name = configuration["SeedUser2:Name"];
            var user2ProfilePictureUrl = configuration["SeedUser2:ProfilePictureUrl"];

            await CreateUserWithRole(userManager, adminEmail, adminPassword, adminName, adminProfilePictureUrl,
                Roles.Admin);

            await CreateUserWithRole(userManager, user1Email, user1Password, user1Name, user1ProfilePictureUrl,
                Roles.User);

            await CreateUserWithRole(userManager, user2Email, user2Password, user2Name, user2ProfilePictureUrl,
                Roles.User);
        }

        public static async Task CreateUserWithRole(UserManager<ApplicationUser> userManager, string email,
            string password, string name, string profilePictureUrl, string role)
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
                    IsDeleted = false
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
