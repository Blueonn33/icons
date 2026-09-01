using icons.Core.Dtos.Review;
using System.ComponentModel.DataAnnotations;
using icons.Core.Enums;
using static icons.Data.Constants.ValidationConstants;

namespace icons.Models.Icons
{
    public class IconViewModel
    {
        [Key]
        public int Id
        {
            get; set;
        }

        [Required]
        [StringLength(IconImageUrlLength)]
        public string ImageUrl
        {
            get; set;
        } = null!;

        [Required]
        [MinLength(IconTitleMinLength)]
        [MaxLength(IconTitleMaxLength)]
        public string Title
        {
            get; set;
        } = null!;

        [MinLength(IconDescriptionMinLength)]
        [MaxLength(IconDescriptionMaxLength)]
        public string? Description
        {
            get; set;
        }

        [Range(IconAverageRangeMinValue, IconAverageRangeMaxValue)]
        public double AverageRating
        {
            get; set;
        }

        [Required]
        [MinLength(IconUsernameMinLength)]
        [MaxLength(IconUsernameMaxLength)]
        public string Username
        {
            get; set;
        } = null!;

        [Required]
        [StringLength(UserProfilePictureUrlLength)]
        public string UserProfilePictureUrl
        {
            get; set;
        } = null!;

        public string UserId
        {
            get; set;
        } = null!;

        public List<ReviewGetDto> Reviews
        {
            get; set;
        } = new();

        public EnumReviewSortOptions Sort
        {
            get; set;
        }
    }
}
