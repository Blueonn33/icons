namespace icons.Core.DTO.Leaderboard.Response
{
    public class GetAllUsersLeaderboardResponseData
    {
        public IEnumerable<GetUserLeaderboardResponseData> Users { get; set; } = new List<GetUserLeaderboardResponseData>();
    }
}
