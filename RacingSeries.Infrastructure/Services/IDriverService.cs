using RacingSeries.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Infrastructure.Services
{
    public interface IDriverService
    {
        Task<IEnumerable<DriverDTO>> BrowseAll();
        Task<DriverDTO> GetDriver(int id);
        Task AddDriver(DriverDTO driver);
        Task EditDriver(DriverDTO driver ,int id);
        Task DeleteDriver(int id);
    }
}
