using icons.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static icons.Data.Constants.ValidationConstants;
namespace icons.Data;
// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public ApplicationUser()
    {
        this.ProfilePictureUrl =
            "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdn.pfps.gg%2Fpfps%2F5623-byakuya-kuchiki-profile-image.png&f=1&nofb=1&ipt=64ca4562e078e950da79e8feb4bd67ff9476530892e91f410071a7110c490556";
    }

    // TODO: Трябва да задам на Username стойността на email, а за име да се използва Name. Username си остава за Email. Да се редактира в appsettings.json, както и в UserSeeder
    [Required]
    public string Name
    {
        get; set;
    } = null!;

    [StringLength(UserProfilePictureUrlLength)]
    public string ProfilePictureUrl
    {
        get;
        set;
    }

    public bool IsDeleted
    {
        get; set;
    }

    public virtual ICollection<Icon> Icons { get; set; } = new HashSet<Icon>();
    public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
}
