using icons.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static icons.Data.Constants.ValidationConstants;

namespace icons.Data.Models
{
    public class Note : IEntity
    {
        [Key]
        public int Id
        {
            get; set;
        }

        [Required]
        [MaxLength(NoteContentMaxLength)]
        public string Content
        {
            get; set;
        } = null!;

        [Required]
        [ForeignKey(nameof(Sender))]
        public string SenderId
        {
            get; set;
        } = null!;

        public virtual ApplicationUser Sender
        {
            get; set;
        } = null!;

        [Required]
        [ForeignKey(nameof(Receiver))]
        public string ReceiverId
        {
            get; set;
        } = null!;

        public virtual ApplicationUser Receiver
        {
            get; set;
        } = null!;
    }
}
