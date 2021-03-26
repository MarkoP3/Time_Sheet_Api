using System;
using System.Collections.Generic;

#nullable disable

namespace timeSheet.Repository.InMSSQLDB.EntitiesDB
{
    public partial class Project
    {
        public Project()
        {
            Engagements = new HashSet<Engagement>();
        }

        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid LeadId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public virtual Client Client { get; set; }
        public virtual TeamMember Lead { get; set; }
        public virtual ICollection<Engagement> Engagements { get; set; }
    }
}
