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
    public class SponsorService : ISponsorService
    {
        private readonly ISponsorRepository _SponsorRepository;
        public SponsorService(ISponsorRepository SponsorRepository)
        {
            _SponsorRepository = SponsorRepository;
        }
        public async Task AddSponsor(SponsorDTO Sponsor)
        {
            await _SponsorRepository.AddAsync(new Sponsor()
            {
                Id = Sponsor.Id,
                Name = Sponsor.Name,
                Description = Sponsor.Description
            });
        }

        public async Task<IEnumerable<SponsorDTO>> BrowseAll()
        {
            var z = await _SponsorRepository.BrowseAllAsync();
            return z.Select(x => new SponsorDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            });
        }

        public async Task DeleteSponsor(int id)
        {
            await _SponsorRepository.DelAsync(new Sponsor()
            {
                Id = id
            });
            await Task.CompletedTask;
        }

        public async Task EditSponsor(SponsorDTO Sponsor, int id)
        {
            await _SponsorRepository.UpdateAsync(new Sponsor()
            {
                Id = id,
                Name = Sponsor.Name,
                Description = Sponsor.Description
            });
            await Task.CompletedTask;
        }

        public async Task<SponsorDTO> GetSponsor(int id)
        {
            var z = await _SponsorRepository.GetAsync(id);

            return new SponsorDTO()
            {
                Id = z.Id,
                Name = z.Name,
                Description = z.Description
            };
        }
    }
}
