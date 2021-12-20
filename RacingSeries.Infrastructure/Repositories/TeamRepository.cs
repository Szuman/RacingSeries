using RacingSeries.Core.Domain;
using RacingSeries.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        public Task AddAsync(Team team)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Team>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(Team team)
        {
            throw new NotImplementedException();
        }

        public Task<Team> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Team team)
        {
            throw new NotImplementedException();
        }
    }
}
