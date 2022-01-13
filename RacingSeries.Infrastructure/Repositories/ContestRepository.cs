using RacingSeries.Core.Domain;
using RacingSeries.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Infrastructure.Repositories
{
    public class ContestRepository : IContestRepository
    {
        private AppDbContext _appDbContext;
        public ContestRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Contest Contest)
        {
            try
            {
                _appDbContext.Add(Contest);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Contest>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Contests);
        }

        public async Task DelAsync(Contest Contest)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Contests.FirstOrDefault(x => x.Id == Contest.Id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Contest> GetAsync(int id)
        {
            var z = _appDbContext.Contests.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(z);
        }

        public async Task UpdateAsync(Contest Contest)
        {
            try
            {
                var z = _appDbContext.Contests.FirstOrDefault(x => x.Id == Contest.Id);

                z.Id = Contest.Id;
                z.Name = Contest.Name;
                z.DateTime = Contest.DateTime;

                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
