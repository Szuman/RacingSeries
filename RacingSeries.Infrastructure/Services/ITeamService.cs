using RacingSeries.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Infrastructure.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamDTO>> BrowseAll();
        Task<TeamDTO> GetTeam(int id);
        Task AddTeam(TeamDTO team);
        Task EditTeam(TeamDTO team, int id);
        Task DeleteTeam(int id);
    }
}
