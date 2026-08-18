using System.ComponentModel.DataAnnotations;

namespace icons.Data.Models
{
    public class Review
    {
        [Key]
        public int ReviewId
        {
            get; set;
        }

        [Required]
        public string Title { get; set; } = null!;

    }
}
