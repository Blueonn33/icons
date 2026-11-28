using System.ComponentModel.DataAnnotations;
using static icons.Data.Constants.ValidationConstants;

namespace icons.Core.ViewModels.Messages
{
    public class MessageInputModel
    {
        [Required(ErrorMessage = "Въведи съобщение")]
        [StringLength(MessageContentMaxLength, MinimumLength = MessageContentMinLength)]
        public string Content
        {
            get; set;
        } = null!;

        public string ReceiverId
        {
            get; set;
        } = null!;
    }
}
