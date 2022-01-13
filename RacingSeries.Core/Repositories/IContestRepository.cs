using RacingSeries.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Core.Repositories
{
    public interface IContestRepository
    {
        public Task<IEnumerable<Contest>> BrowseAllAsync();
        public Task AddAsync(Contest Contest);
        public Task DelAsync(Contest Contest);
        public Task UpdateAsync(Contest Contest);
        public Task<Contest> GetAsync(int id);
    }
}
