using icons.Data.Constants;
using icons.Data.Enums;
using icons.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace icons.Data.Seed
{
    public class UserSeeder
    {
        public static async Task SeedUsersAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var admin = new ApplicationUser()
            {
                Id = "cb5d1652-65c2-4990-b240-f6a3ce1e4a18",
                Email = "admin@icons.com",
                Name = "icons_admin😎",
                ProfilePictureUrl =
                    "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdn.pfps.gg%2Fpfps%2F3724-byakuya-kuchiki-profile-icon.png&f=1&nofb=1&ipt=1beed75c5a39ad22460afe00100ca77025d4732b11d0375487bfd71fd09d8907",
                Elixir = 11999,
                Rank = EnumUserElixirRank.Admin
            };

            var user1 = new ApplicationUser()
            {
                Id = "18d96ab2-c4b3-4f7f-9af5-735e9dbcd348",
                Email = "levi119@gmail.com",
                Name = "Levi Ackerman",
                ProfilePictureUrl =
                    "https://aniyuki.com/wp-content/uploads/2025/03/aniyuki-Levi-Ackerman-avatar-15.jpg",
                Elixir = 2578,
                Rank = EnumUserElixirRank.Captain
            };

            var user2 = new ApplicationUser()
            {
                Id = "fca0ea4c-bc91-4d6d-8c95-f1ef4e3d71e6",
                Email = "byakuya117@gmail.com",
                Name = "Byakuya Kuchiki",
                ProfilePictureUrl =
                    "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdn.pfps.gg%2Fpfps%2F5623-byakuya-kuchiki-profile-image.png&f=1&nofb=1&ipt=64ca4562e078e950da79e8feb4bd67ff9476530892e91f410071a7110c490556",
                Elixir = 1992,
                Rank = EnumUserElixirRank.Titan
            };

            await CreateUserWithRole(userManager, user1.Id, user1.Email, "Levi119@", user1.Name, user1.ProfilePictureUrl, user1.Elixir, user1.Rank,
                Roles.User);

            await CreateUserWithRole(userManager, user2.Id, user2.Email, "*ByakuyaK117*", user2.Name, user2.ProfilePictureUrl, user2.Elixir, user2.Rank,
                Roles.User);

            await CreateUserWithRole(userManager, admin.Id, admin.Email, "Admin123!", admin.Name, admin.ProfilePictureUrl, admin.Elixir, admin.Rank,
                Roles.Admin);
        }

        public static async Task CreateUserWithRole(UserManager<ApplicationUser> userManager, string id, string email,
            string password, string name, string profilePictureUrl, int elixir, EnumUserElixirRank rank, string role)
        {
            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new ApplicationUser
                {
                    Id = id,
                    Email = email,
                    NormalizedEmail = email.ToUpper(),
                    EmailConfirmed = true,
                    UserName = email,
                    NormalizedUserName = email.ToUpper(),
                    Name = name,
                    ProfilePictureUrl = profilePictureUrl,
                    IsDeleted = false,
                    Elixir = elixir,
                    Rank = rank
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
