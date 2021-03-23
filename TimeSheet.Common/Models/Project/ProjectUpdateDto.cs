using System;

namespace timeSheet.Common.Models.Project
{
    public class ProjectUpdateDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid LeadId { get; set; }
        public string Lead { get; set; }
        public string Customer { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
