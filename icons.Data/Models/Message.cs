using icons.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static icons.Data.Constants.ValidationConstants;

namespace icons.Data.Models
{
    public class Message : IEntity
    {
        public int Id
        {
            get; set;
        }

        [Required]
        [MaxLength(MessageContentMaxLength)]
        public string Content
        {
            get; set;
        } = null!;

        public DateTime SentTime
        {
            get; set;
        }

        [Required]
        [ForeignKey(nameof(Sender))]
        public string SenderId
        {
            get; set;
        } = null!;

        public ApplicationUser Sender { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Receiver))]
        public string ReceiverId
        {
            get; set;
        } = null!;

        public ApplicationUser Receiver { get; set; } = null!;
    }
}
