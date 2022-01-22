using System;
using System.Collections.Generic;
using System.Text;

namespace RacingSeries.Infrastructure.DTO
{
    public class UpdateDriver
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
