using System;
using System.Collections.Generic;
using System.Text;

namespace RacingSeries.Core.Domain
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime EntryDate { get; set; }
        public List<Sponsor> Sponsors { get; set; }
    }
}
