using RacingSeries.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Core.Repositories
{
    public interface ITeamRepository
    {
        public Task<IEnumerable<Team>> BrowseAllAsync();
        public Task AddAsync(Team team);
        public Task DelAsync(Team team);
        public Task UpdateAsync(Team team);
        public Task<Team> GetAsync(int id);
    }
}
