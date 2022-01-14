using System;

namespace RacingSeries.WebApp.Models
{
    public class TeamVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
