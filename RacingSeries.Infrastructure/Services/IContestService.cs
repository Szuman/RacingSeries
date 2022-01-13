using RacingSeries.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Infrastructure.Services
{
    public interface IContestService
    {
        Task<IEnumerable<ContestDTO>> BrowseAll();
        Task<ContestDTO> GetContest(int id);
        Task AddContest(ContestDTO Contest);
        Task EditContest(ContestDTO Contest, int id);
        Task DeleteContest(int id);
    }
}
