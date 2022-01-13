using RacingSeries.Core.Domain;
using RacingSeries.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Infrastructure.Repositories
{
    public class ContestRepository : IContestRepository
    {
        public Task AddAsync(Contest Contest)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contest>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(Contest Contest)
        {
            throw new NotImplementedException();
        }

        public Task<Contest> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Contest Contest)
        {
            throw new NotImplementedException();
        }
    }
}
