using System;

namespace timeSheet.Services.Contract.Models.Project
{
    public class ProjectConfirmationDto
    {
        public Guid Id { get; set; }
        public string Lead { get; set; }
        public string Customer { get; set; }
        public string Name { get; set; }
    }
}
