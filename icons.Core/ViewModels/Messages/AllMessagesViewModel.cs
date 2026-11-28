namespace icons.Core.ViewModels.Messages
{
    public class AllMessagesViewModel
    {
        public string ReceiverId
        {
            get; set;
        } = null!;

        public string ReceiverProfilePic
        {
            get; set;
        } = null!;

        public string ReceiverName
        {
            get; set;
        } = null!;

        public IEnumerable<BaseMessageViewModel> Messages { get; set; } = new List<BaseMessageViewModel>();
    }
}
