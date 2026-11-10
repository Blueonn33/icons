using AutoMapper;
using icons.Core.DTO.Leaderboard.Response;
using icons.Core.ViewModels.Leaderboard;
using icons.Data.Models;

namespace icons.Core.Mappings
{
    public class LeaderboardProfile : Profile
    {
        public LeaderboardProfile()
        {
            CreateMap<ApplicationUser, GetUserLeaderboardResponseData>();
            CreateMap<GetUserLeaderboardResponseData, UserLeaderboardViewModel>();
        }
    }
}
