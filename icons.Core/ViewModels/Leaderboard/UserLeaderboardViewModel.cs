namespace icons.Core.ViewModels.Leaderboard
{
    public class UserLeaderboardViewModel
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
