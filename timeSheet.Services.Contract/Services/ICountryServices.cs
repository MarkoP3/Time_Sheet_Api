using System.Collections.Generic;
using timeSheet.Services.Contract.Models.Country;

namespace timeSheet.Services.Contract.Services
{
    public interface ICountryServices
    {
        IEnumerable<CountryDto> GetAllCountries();
    }
}
