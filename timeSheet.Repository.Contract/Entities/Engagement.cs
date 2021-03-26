﻿using System;
using System.Collections.Generic;

#nullable disable

namespace timeSheet.Repository.Contract.Entities
{
    public partial class Engagement
    {
        public Engagement()
        {
            SpentHours = new HashSet<SpentHour>();
        }

        public Guid Id { get; set; }
        public Guid TeamMemberId { get; set; }
        public Guid ProjectId { get; set; }

        public virtual Project Project { get; set; }
        public virtual TeamMember TeamMember { get; set; }
        public virtual ICollection<SpentHour> SpentHours { get; set; }
    }
}
