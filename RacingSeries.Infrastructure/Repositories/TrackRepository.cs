using RacingSeries.Core.Domain;
using RacingSeries.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Infrastructure.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        public Task AddAsync(Track track)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Track>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(Track track)
        {
            throw new NotImplementedException();
        }

        public Task<Track> GetAsync(Track track)
        {
            throw new NotImplementedException();
        }

        public Task<Track> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Track track)
        {
            throw new NotImplementedException();
        }
    }
}
