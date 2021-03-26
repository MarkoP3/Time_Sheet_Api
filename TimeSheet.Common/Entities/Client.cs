using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace timeSheet.Common.Entities
{
    public partial class Client
    {
        public Client()
        {
            Projects = new HashSet<Project>();
        }

        public Client(Guid id, Guid countryId, string name, string address, string city, string postal, string country)
        {
            Id = id;
            CountryId = countryId;
            Name = name ?? throw new ValidationException();
            Address = address ?? throw new ValidationException();
            City = city ?? throw new ValidationException();
            Postal = postal ?? throw new ValidationException();
            Country = country ?? throw new ValidationException();
        }
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value != null)
                    name = value;
                else
                    throw new ValidationException();
            }
        }
        public string Address { get; set; }

        public string City { get; set; }

        public string Postal { get; set; }

        public virtual string Country { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
