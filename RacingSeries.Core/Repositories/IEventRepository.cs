using RacingSeries.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Core.Repositories
{
    public interface IEventRepository
    {
        public Task<IEnumerable<Event>> BrowseAllAsync();
        public Task AddAsync(Event _event);
        public Task DelAsync(Event _event);
        public Task UpdateAsync(Event _event);
        public Task<Event> GetAsync(int id);
    }
}
