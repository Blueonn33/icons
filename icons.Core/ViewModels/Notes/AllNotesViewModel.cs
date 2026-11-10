namespace icons.Core.ViewModels.Notes
{
    public class AllNotesViewModel
    {
        public IEnumerable<NoteUserProfileViewModel> Notes { get; set; } = new List<NoteUserProfileViewModel>();
    }
}
