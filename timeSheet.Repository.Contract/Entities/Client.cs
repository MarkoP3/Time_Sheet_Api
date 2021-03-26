using System;
using System.ComponentModel.DataAnnotations;

namespace timeSheet.Repository.Contract.Entities
{
    public partial class Client
    {
        public Client(Guid id, Guid countryId, string name, string address, string city, string postal, string country)
        {
            if (String.IsNullOrEmpty(name))
                throw new ValidationException();
            Id = id;
            CountryId = countryId;
            Name = name;
            Address = address;
            City = city;
            Postal = postal;
            Country = country;
        }
        public Guid Id { get; }
        public Guid CountryId { get; }
        public string Name { get; }

        public string Address { get; }

        public string City { get; }

        public string Postal { get; }

        public string Country { get; }
    }
}
