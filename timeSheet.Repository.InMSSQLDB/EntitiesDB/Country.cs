using System;
using System.Collections.Generic;

#nullable disable

namespace timeSheet.Repository.InMSSQLDB.EntitiesDB
{
    public partial class Country
    {
        public Country()
        {
            Clients = new HashSet<Client>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
