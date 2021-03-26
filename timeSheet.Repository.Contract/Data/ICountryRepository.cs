using System.Collections.Generic;
using timeSheet.Repository.Contract.Entities;

namespace timeSheet.Repository.Contract.Data
{
    public interface ICountryRepository
    {
        IList<Country> GetAllCountries();
    }
}
