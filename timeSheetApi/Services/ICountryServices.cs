using System.Collections.Generic;
using timeSheetApi.Models.Country;

namespace timeSheetApi.Services
{
    public interface ICountryServices
    {
        IList<CountryDto> GetAllCountries();
    }
}
