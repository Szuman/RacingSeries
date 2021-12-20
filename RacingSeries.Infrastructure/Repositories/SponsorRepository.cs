using RacingSeries.Core.Domain;
using RacingSeries.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Infrastructure.Repositories
{
    public class SponsorRepository : ISponsorRepository
    {
        public Task AddAsync(Sponsor sponsor)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sponsor>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(Sponsor sponsor)
        {
            throw new NotImplementedException();
        }

        public Task<Sponsor> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Sponsor sponsor)
        {
            throw new NotImplementedException();
        }
    }
}
