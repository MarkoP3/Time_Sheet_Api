using System.Collections.Generic;
using timeSheet.Common.Entities;

namespace timeSheet.Data.Data
{
    public interface ICountryRepository
    {
        IList<Country> GetAllCountries();
    }
}
