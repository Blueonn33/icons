using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace icons.Data.EntityTypeConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            var user1 = new ApplicationUser
            {
                Id = "user-seed-1",
                Email = "mmarinov17@gmail.com",
                EmailConfirmed = true,
                NormalizedEmail = "MMARINOV17@GMAIL.COM",
                UserName = "Sapphire",
                NormalizedUserName = "SAPPHIRE",
                SecurityStamp = "seed-user-1-security-stamp",
                ConcurrencyStamp = "seed-user-1-concurrency-stamp",
                ProfilePictureUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fstatic.wikia.nocookie.net%2Fbleach%2Fimages%2F5%2F5e%2FUkitake_P.Portable.png%2Frevision%2Flatest%3Fcb%3D20230128190156%26path-prefix%3Des&f=1&nofb=1&ipt=8b8a3c9e749de524c769ebc74f76827cb2c922ae27139e40da3d8795e6874485"
            };
            var user2 = new ApplicationUser
            {
                Id = "user-seed-2",
                Email = "marinov117@gmail.com",
                EmailConfirmed = true,
                NormalizedEmail = "MARINOV117@GMAIL.COM",
                UserName = "Indigo",
                NormalizedUserName = "INDIGO",
                SecurityStamp = "seed-user-2-security-stamp",
                ConcurrencyStamp = "seed-user-2-concurrency-stamp",
                ProfilePictureUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdn.pfps.gg%2Fpfps%2F5623-byakuya-kuchiki-profile-image.png&f=1&nofb=1&ipt=64ca4562e078e950da79e8feb4bd67ff9476530892e91f410071a7110c490556"
            };

            user1.PasswordHash = hasher.HashPassword(user1, "Ukitake119@");
            user2.PasswordHash = hasher.HashPassword(user2, "*ByakuyaK117*");

            builder.HasData(user1, user2);
        }
    }
}
