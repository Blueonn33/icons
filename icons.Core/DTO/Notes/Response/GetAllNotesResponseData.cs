namespace icons.Core.DTO.Notes.Response
{
    public class GetAllNotesResponseData
    {
        public IEnumerable<GetNoteResponseData> Notes { get; set; } = new List<GetNoteResponseData>();
    }
}
