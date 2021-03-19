using System;
using System.Collections.Generic;

#nullable disable

namespace timeSheetApi.Entities
{
    public partial class Category
    {
        public Category()
        {
            SpentHours = new HashSet<SpentHour>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SpentHour> SpentHours { get; set; }
    }
}
