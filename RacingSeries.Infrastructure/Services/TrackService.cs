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
    public class TrackService : ITrackService
    {
            private readonly ITrackRepository _TrackRepository;
            public TrackService(ITrackRepository TrackRepository)
            {
                _TrackRepository = TrackRepository;
            }
            public async Task AddTrack(TrackDTO Track)
            {
                await _TrackRepository.AddAsync(new Track()
                {
                    Id = Track.Id,
                    Name = Track.Name,
                    City = Track.City,
                    Country = Track.Country,
                });
            }

            public async Task<IEnumerable<TrackDTO>> BrowseAll()
            {
                var z = await _TrackRepository.BrowseAllAsync();
                return z.Select(x => new TrackDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    City = x.City,
                    Country = x.Country
                });
            }

            public async Task DeleteTrack(int id)
            {
                await _TrackRepository.DelAsync(new Track()
                {
                    Id = id
                });
                await Task.CompletedTask;
            }

            public async Task EditTrack(TrackDTO Track, int id)
            {
                await _TrackRepository.UpdateAsync(new Track()
                {
                    Id = id,
                    Name = Track.Name,
                    City = Track.City,
                    Country = Track.Country
                });
                await Task.CompletedTask;
            }

            public async Task<TrackDTO> GetTrack(int id)
            {
                var z = await _TrackRepository.GetAsync(id);

                return new TrackDTO()
                {
                    Id = z.Id,
                    Name = z.Name,
                    City = z.City,
                    Country = z.Country
                };
            }
        }
}
