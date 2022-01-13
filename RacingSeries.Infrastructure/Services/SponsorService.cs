using RacingSeries.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Infrastructure.Services
{
    public class SponsorService : ISponsorService
    {
        public Task AddSponsor(SponsorDTO sponsor)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SponsorDTO>> BrowseAll()
        {
            throw new NotImplementedException();
        }

        public Task DeleteSponsor(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditSponsor(SponsorDTO sponsor, int id)
        {
            throw new NotImplementedException();
        }

        public Task<TrackDTO> GetSponsor(int id)
        {
            throw new NotImplementedException();
        }
    }
}
