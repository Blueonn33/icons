namespace icons.Core.ViewModels.Messages
{
    public class MessageViewModel
    {
        public IEnumerable<MessageReceiverViewModel> ReceiverMessages { get; set; } = new List<MessageReceiverViewModel>();
        public IEnumerable<MessageSenderViewModel> SenderMessages { get; set; } = new List<MessageSenderViewModel>();
    }
}
