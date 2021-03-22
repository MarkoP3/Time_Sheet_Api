using System.Collections.Generic;
using timeSheetApi.Entities;

namespace timeSheetApi.Data
{
    public interface ICountryRepository
    {
        IList<Country> GetAllCountries();
    }
}
