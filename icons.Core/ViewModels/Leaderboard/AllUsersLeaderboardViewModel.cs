namespace icons.Core.ViewModels.Leaderboard
{
    public class AllUsersLeaderboardViewModel
    {
        public IEnumerable<UserLeaderboardViewModel> Users { get; set; } = new List<UserLeaderboardViewModel>();
    }
}
