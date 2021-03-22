using System;
using System.Collections.Generic;

#nullable disable

namespace timeSheetApi.Entities
{
    public partial class Client
    {
        public Client()
        {
            Projects = new HashSet<Project>();
        }

        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Postal { get; set; }

        public virtual string Country { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
