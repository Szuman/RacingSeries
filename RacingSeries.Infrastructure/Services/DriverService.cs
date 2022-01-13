using RacingSeries.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        public Task AddDriver(DriverDTO driver)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DriverDTO>> BrowseAll()
        {
            throw new NotImplementedException();
        }

        public Task DeleteDriver(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditDriver(DriverDTO driver, int id)
        {
            throw new NotImplementedException();
        }

        public Task<DriverDTO> GetDriver(int id)
        {
            throw new NotImplementedException();
        }
    }
}
