using RacingSeries.Core.Domain;
using RacingSeries.Core.Repositories;
using RacingSeries.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }
        public async Task AddDriver(DriverDTO driver)
        {
            await _driverRepository.AddAsync(new Driver()
            {
                Id = driver.Id,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                Country = driver.Country,
                BirthDate = driver.BirthDate,
            });
        }

        public async Task<IEnumerable<DriverDTO>> BrowseAll()
        {
            var z = await _driverRepository.BrowseAllAsync();
            return z.Select(x => new DriverDTO()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Country = x.Country,
                BirthDate = x.BirthDate,
            });
        }

        public async Task DeleteDriver(int id)
        {
            await _driverRepository.DelAsync(new Driver()
            {
                Id = id
            });
            await Task.CompletedTask;
        }

        public async Task EditDriver(DriverDTO driver, int id)
        {
            await _driverRepository.UpdateAsync(new Driver()
            {
                Id = id,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                Country = driver.Country,
                BirthDate = driver.BirthDate
            });
            await Task.CompletedTask;
        }

        public async Task<DriverDTO> GetDriver(int id)
        {
            var z = await _driverRepository.GetAsync(id);

            return new DriverDTO()
            {
                Id = z.Id,
                FirstName = z.FirstName,
                LastName = z.LastName,
                Country = z.Country,
                BirthDate = z.BirthDate,
            };
        }
    }
}
