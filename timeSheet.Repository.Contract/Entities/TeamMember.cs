using System;

#nullable disable

namespace timeSheet.Repository.Contract.Entities
{
    public partial class TeamMember
    {

        public TeamMember(Guid id, string name, string email, string username, string password, decimal hoursPerWeek, string salt, string status, string role)
        {
            Id = id;
            Name = name;
            Email = email;
            Username = username;
            Password = password;
            HoursPerWeek = hoursPerWeek;
            Salt = salt;
            Status = status;
            Role = role;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal HoursPerWeek { get; set; }
        public string Salt { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }

    }
}
