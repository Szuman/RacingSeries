using RacingSeries.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Infrastructure.Services
{
    public interface ITrackService
    {
        Task<IEnumerable<TrackDTO>> BrowseAll();
        Task<TrackDTO> GetTrack(int id);
        Task AddTrack(TrackDTO Track);
        Task EditTrack(TrackDTO Track, int id);
        Task DeleteTrack(int id);
    }
}
