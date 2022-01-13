using RacingSeries.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Infrastructure.Services
{
    public class ContestService : IContestService
    {
        public Task AddContest(ContestDTO Contest)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContestDTO>> BrowseAll()
        {
            throw new NotImplementedException();
        }

        public Task DeleteContest(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditContest(ContestDTO Contest, int id)
        {
            throw new NotImplementedException();
        }

        public Task<ContestDTO> GetContest(int id)
        {
            throw new NotImplementedException();
        }
    }
}
