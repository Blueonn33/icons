namespace icons.Core.DTO.Leaderboard.Response
{
    public class GetUserLeaderboardResponseData
    {
        public string Id
        {
            get; set;
        } = null!;

        public string Name
        {
            get; set;
        } = null!;

        public string? ProfilePictureUrl
        {
            get; set;
        }

        public int Elixir
        {
            get; set;
        }
    }
}
