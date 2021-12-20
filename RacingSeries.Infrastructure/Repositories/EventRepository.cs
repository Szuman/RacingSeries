using RacingSeries.Core.Domain;
using RacingSeries.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        public Task AddAsync(Event _event)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Event>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(Event _event)
        {
            throw new NotImplementedException();
        }

        public Task<Event> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Event _event)
        {
            throw new NotImplementedException();
        }
    }
}
