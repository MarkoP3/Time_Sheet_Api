using System.Collections.Generic;
using timeSheet.Common.Models.Country;

namespace timeSheet.Services.Services
{
    public interface ICountryServices
    {
        IList<CountryDto> GetAllCountries();
    }
}
