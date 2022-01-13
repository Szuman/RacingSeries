using RacingSeries.Core.Repositories;
using RacingSeries.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RacingSeries.Core.Domain;
using System.Linq;

namespace RacingSeries.Infrastructure.Services
{
    public class ContestService : IContestService
    {
        private readonly IContestRepository _contestRepository;
        public ContestService(IContestRepository contestRepository)
        {
            _contestRepository = contestRepository;
        }
        public async Task AddContest(ContestDTO Contest)
        {
            await _contestRepository.AddAsync(new Contest()
            {
                Id = Contest.Id,
                Name = Contest.Name,
                DateTime = Contest.DateTime,
            });
        }

        public async Task<IEnumerable<ContestDTO>> BrowseAll()
        {
            var z = await _contestRepository.BrowseAllAsync();
            return z.Select(x => new ContestDTO()
            {
                Id = x.Id,
                Name = x.Name,
                DateTime = x.DateTime
            });
        }

        public async Task DeleteContest(int id)
        {
            await _contestRepository.DelAsync(new Contest()
            {
                Id = id
            });
            await Task.CompletedTask;
        }

        public async Task EditContest(ContestDTO Contest, int id)
        {
            await _contestRepository.UpdateAsync(new Contest()
            {
                Id = id,
                Name = Contest.Name,
                DateTime = Contest.DateTime,
            });
            await Task.CompletedTask;
        }

        public async Task<ContestDTO> GetContest(int id)
        {
            var z = await _contestRepository.GetAsync(id);

            return new ContestDTO()
            {
                Id = z.Id,
                Name = z.Name,
                DateTime = z.DateTime
            };
        }
    }
}
