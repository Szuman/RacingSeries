using RacingSeries.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Infrastructure.Services
{
    public class TrackService : ITrackService
    {
        public Task AddTrack(TrackDTO Track)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TrackDTO>> BrowseAll()
        {
            throw new NotImplementedException();
        }

        public Task DeleteTrack(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditTrack(TrackDTO Track, int id)
        {
            throw new NotImplementedException();
        }

        public Task<TrackDTO> GetTrack(int id)
        {
            throw new NotImplementedException();
        }
    }
}
