using RacingSeries.Core.Domain;
using RacingSeries.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Infrastructure.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private AppDbContext _appDbContext;
        public TrackRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Track Track)
        {
            try
            {
                _appDbContext.Add(Track);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Track>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Tracks);
        }

        public async Task DelAsync(Track Track)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Tracks.FirstOrDefault(x => x.Id == Track.Id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Track> GetAsync(int id)
        {
            var z = _appDbContext.Tracks.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(z);
        }

        public async Task UpdateAsync(Track Track)
        {
            try
            {
                var z = _appDbContext.Tracks.FirstOrDefault(x => x.Id == Track.Id);

                z.Name = Track.Name;
                z.City = Track.City;
                z.Country = Track.Country;

                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
