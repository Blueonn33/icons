using System;
using System.Collections.Generic;
using System.Text;
using icons.Core.DTO.Leaderboard.Response;

namespace icons.Core.Contracts
{
    public interface ILeaderboardService
    {
        Task<GetAllUsersLeaderboardResponseData> GetAllUsersAsync();
    }
}
