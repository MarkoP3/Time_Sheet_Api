using System;
using System.Collections.Generic;
using timeSheet.Common.Entities;

namespace timeSheet.Data.Data
{
    public class mockCountryRepository : ICountryRepository
    {
        IList<Country> countries = new List<Country>();
        public mockCountryRepository()
        {
            countries.Add(new Country() { Id = Guid.Parse("fd780814-2d8a-40bb-b31d-c1220299006c"), Name = "Serbia" });
            countries.Add(new Country() { Id = Guid.Parse("7572dd90-9661-41ab-bfbc-1ab00b3ae502"), Name = "Bosnia" });

        }
        public IList<Country> GetAllCountries()
        {
            return countries;
        }
    }
}
