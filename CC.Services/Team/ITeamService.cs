using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CC.Models.Team;

namespace CC.Services.Team
{
    public interface ITeamService
    {
        Task<bool> CreateTeamAsync(TeamCreate model);
    }
}