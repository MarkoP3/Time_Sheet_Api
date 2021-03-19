using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using timeSheetApi.Models;

namespace timeSheetApi.Data
{
    public class mockCountryRepository : ICountryRepository
    {
        IList<CountryDto> countries = new List<CountryDto>();
        public mockCountryRepository()
        {
            countries.Add(new CountryDto() {Id=Guid.Parse("fd780814-2d8a-40bb-b31d-c1220299006c"),Name="Serbia" });
            countries.Add(new CountryDto() { Id = Guid.Parse("7572dd90-9661-41ab-bfbc-1ab00b3ae502"), Name = "Bosnia" });

        }
        public IList<CountryDto> GetAllCountrues()
        {
            return countries;
        }
    }
}
