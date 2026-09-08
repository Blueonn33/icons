using icons.Data.Enums;
using icons.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static icons.Data.Constants.ValidationConstants;
namespace icons.Data;
// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [Required]
    [MinLength(UserNameMinLength)]
    [MaxLength(UserNameMaxLength)]
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

    public DateTime DateRegistered
    {
        get; set;
    }

    public int Elixir
    {
        get; set;
    }

    public EnumUserElixirRank Rank
    {
        get; set;
    }

    public virtual ICollection<Icon> Icons { get; set; } = new HashSet<Icon>();
    public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
}
