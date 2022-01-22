using RacingSeries.Core.Domain;
using RacingSeries.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private AppDbContext _appDbContext;
        public TeamRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Team Team)
        {
            try
            {
                _appDbContext.Add(Team);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Team>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Teams);
        }

        public async Task DelAsync(Team Team)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Teams.FirstOrDefault(x => x.Id == Team.Id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Team> GetAsync(int id)
        {
            var z = _appDbContext.Teams.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(z);
        }

        public async Task UpdateAsync(Team Team)
        {
            try
            {
                var z = _appDbContext.Teams.FirstOrDefault(x => x.Id == Team.Id);

                z.Name = Team.Name;
                z.Country = Team.Country;
                z.EntryDate = Team.EntryDate;

                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
