using System.Collections.Generic;
using timeSheet.Common.Entities;

namespace timeSheet.Services.Data
{
    public interface ICountryRepository
    {
        IList<Country> GetAllCountries();
    }
}
