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
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _TeamRepository;
        public TeamService(ITeamRepository TeamRepository)
        {
            _TeamRepository = TeamRepository;
        }
        public async Task AddTeam(TeamDTO Team)
        {
            await _TeamRepository.AddAsync(new Team()
            {
                Id = Team.Id,
                Name = Team.Name,
                EntryDate = Team.EntryDate,
            });
        }

        public async Task<IEnumerable<TeamDTO>> BrowseAll()
        {
            var z = await _TeamRepository.BrowseAllAsync();
            return z.Select(x => new TeamDTO()
            {
                Id = x.Id,
                Name = x.Name,
                EntryDate = x.EntryDate,
            });
        }

        public async Task DeleteTeam(int id)
        {
            await _TeamRepository.DelAsync(new Team()
            {
                Id = id
            });
            await Task.CompletedTask;
        }

        public async Task EditTeam(TeamDTO Team, int id)
        {
            await _TeamRepository.UpdateAsync(new Team()
            {
                Id = id,
                Name = Team.Name,
                EntryDate = Team.EntryDate
            });
            await Task.CompletedTask;
        }

        public async Task<TeamDTO> GetTeam(int id)
        {
            var z = await _TeamRepository.GetAsync(id);

            return new TeamDTO()
            {
                Id = z.Id,
                Name = z.Name,
                EntryDate = z.EntryDate
            };
        }
    }
}
