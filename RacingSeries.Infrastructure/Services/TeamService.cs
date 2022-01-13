using RacingSeries.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Infrastructure.Services
{
    public class TeamService : ITeamService
    {
        public Task AddTeam(TeamDTO team)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TeamDTO>> BrowseAll()
        {
            throw new NotImplementedException();
        }

        public Task DeleteTeam(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditTeam(TeamDTO team, int id)
        {
            throw new NotImplementedException();
        }

        public Task<TeamDTO> GetTeam(int id)
        {
            throw new NotImplementedException();
        }
    }
}
