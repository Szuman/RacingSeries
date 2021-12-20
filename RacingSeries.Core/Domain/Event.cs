using System;
using System.Collections.Generic;
using System.Text;

namespace RacingSeries.Core.Domain
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Track Track { get; set; }
        public DateTime DateTime { get; set; }
        public List<Driver> Drivers { get; set; }
    }
}
