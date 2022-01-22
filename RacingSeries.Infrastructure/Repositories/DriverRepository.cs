using RacingSeries.Core.Domain;
using RacingSeries.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Infrastructure.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private AppDbContext _appDbContext;
        public DriverRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Driver driver)
        {
            try
            {
                _appDbContext.Add(driver);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Driver>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Drivers);
        }

        public async Task DelAsync(Driver driver)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Drivers.FirstOrDefault(x => x.Id == driver.Id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Driver> GetAsync(int id)
        {
            var z = _appDbContext.Drivers.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(z);
        }

        public async Task UpdateAsync(Driver driver)
        {
            try
            {
                var z = _appDbContext.Drivers.FirstOrDefault(x => x.Id == driver.Id);

                z.FirstName = driver.FirstName;
                z.LastName = driver.LastName;
                z.BirthDate = driver.BirthDate;

                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
