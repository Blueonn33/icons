using System.ComponentModel.DataAnnotations;
using static icons.Data.Constants.ValidationConstants;

namespace icons.Core.ViewModels.Notes
{
    public class NoteInputModel
    {
        public int Id
        {
            get; set;
        }

        public string ReceiverId
        {
            get; set;
        } = null!;

        [Required(ErrorMessage = "Въведи съдържание")]
        [StringLength(NoteContentMaxLength, MinimumLength = NoteContentMinLength)]
        public string Content
        {
            get; set;
        } = null!;
    }
}
