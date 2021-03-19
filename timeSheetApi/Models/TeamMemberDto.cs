using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace timeSheetApi.Models
{
    public class TeamMemberDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public decimal HoursPerWeek { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }
    }
}
