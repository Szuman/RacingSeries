using RacingSeries.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Core.Repositories
{
    public interface ISponsorRepository
    {
        public Task<IEnumerable<Sponsor>> BrowseAllAsync();
        public Task AddAsync(Sponsor sponsor);
        public Task DelAsync(Sponsor sponsor);
        public Task UpdateAsync(Sponsor sponsor);
        public Task<Sponsor> GetAsync(int id);
    }
}
