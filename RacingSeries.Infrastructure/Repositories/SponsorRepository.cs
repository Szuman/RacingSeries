using RacingSeries.Core.Domain;
using RacingSeries.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Infrastructure.Repositories
{
    public class SponsorRepository : ISponsorRepository
    {
        private AppDbContext _appDbContext;
        public SponsorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Sponsor Sponsor)
        {
            try
            {
                _appDbContext.Add(Sponsor);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Sponsor>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Sponsors);
        }

        public async Task DelAsync(Sponsor Sponsor)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Sponsors.FirstOrDefault(x => x.Id == Sponsor.Id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Sponsor> GetAsync(int id)
        {
            var z = _appDbContext.Sponsors.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(z);
        }

        public async Task UpdateAsync(Sponsor Sponsor)
        {
            try
            {
                var z = _appDbContext.Sponsors.FirstOrDefault(x => x.Id == Sponsor.Id);

                z.Name = Sponsor.Name;
                z.Description = Sponsor.Description;

                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
