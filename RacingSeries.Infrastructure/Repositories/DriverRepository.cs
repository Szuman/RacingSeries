using RacingSeries.Core.Domain;
using RacingSeries.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Infrastructure.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        public Task AddAsync(Driver driver)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Driver>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(Driver driver)
        {
            throw new NotImplementedException();
        }

        public Task<Driver> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}
