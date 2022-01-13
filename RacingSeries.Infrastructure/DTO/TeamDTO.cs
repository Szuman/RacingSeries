using System;
using System.Collections.Generic;
using System.Text;

namespace RacingSeries.Infrastructure.DTO
{
    public class TeamDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
