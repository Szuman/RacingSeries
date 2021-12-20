using RacingSeries.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Core.Repositories
{
    public interface IDriverRepository
    {
        public Task<IEnumerable<Driver>> BrowseAllAsync();
        public Task AddAsync(Driver driver);
        public Task DelAsync(Driver driver);
        public Task UpdateAsync(Driver driver);
        public Task<Driver> GetAsync(int id);
    }
}
