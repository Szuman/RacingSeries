using RacingSeries.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Core.Repositories
{
    public interface ITrackRepository
    {
        public Task<IEnumerable<Track>> BrowseAllAsync();
        public Task AddAsync(Track track);
        public Task DelAsync(Track track);
        public Task UpdateAsync(Track track);
        public Task<Track> GetAsync(Track track);
    }
}
