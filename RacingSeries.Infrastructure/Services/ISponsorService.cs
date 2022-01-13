using RacingSeries.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Infrastructure.Services
{
    public interface ISponsorService
    {
        Task<IEnumerable<SponsorDTO>> BrowseAll();
        Task<TrackDTO> GetSponsor(int id);
        Task AddSponsor(SponsorDTO sponsor);
        Task EditSponsor(SponsorDTO sponsor, int id);
        Task DeleteSponsor(int id);
    }
}
