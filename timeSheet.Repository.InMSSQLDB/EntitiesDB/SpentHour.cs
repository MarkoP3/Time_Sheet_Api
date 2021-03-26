using System;

#nullable disable

namespace timeSheet.Repository.InMSSQLDB.EntitiesDB
{
    public partial class SpentHour
    {
        public DateTime Date { get; set; }
        public Guid EngagementId { get; set; }
        public Guid CategoryId { get; set; }
        public string Description { get; set; }
        public decimal Time { get; set; }
        public decimal Overtime { get; set; }

        public virtual Category Category { get; set; }
        public virtual Engagement Engagement { get; set; }
    }
}
