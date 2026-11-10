using AutoMapper;
using icons.Core.Contracts;
using icons.Core.DTO.Leaderboard.Response;
using icons.Data.Common;

namespace icons.Core.Services
{
    public class LeaderboardService(ILeaderboardRepository _leaderboardRepository, IMapper _mapper) : ILeaderboardService
    {
        public async Task<GetAllUsersLeaderboardResponseData> GetAllUsersAsync()
        {
            var users = await _leaderboardRepository.GetAllUsersAsync();
            var usersDto = _mapper.Map<IEnumerable<GetUserLeaderboardResponseData>>(users);

            GetAllUsersLeaderboardResponseData allUsers = new GetAllUsersLeaderboardResponseData()
            {
                Users = usersDto
            };

            return allUsers;
        }
    }
}
