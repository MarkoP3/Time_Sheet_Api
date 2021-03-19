using System;
using System.Collections.Generic;

#nullable disable

namespace timeSheetApi.Entities
{
    public partial class TeamMember
    {
        public TeamMember()
        {
            Engagements = new HashSet<Engagement>();
            Projects = new HashSet<Project>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal HoursPerWeek { get; set; }
        public string Salt { get; set; }
        public bool Status { get; set; }
        public bool Role { get; set; }

        public virtual ICollection<Engagement> Engagements { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
