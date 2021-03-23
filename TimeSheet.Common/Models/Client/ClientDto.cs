using System;

namespace timeSheet.Common.Models.Client
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Postal { get; set; }
    }
}
