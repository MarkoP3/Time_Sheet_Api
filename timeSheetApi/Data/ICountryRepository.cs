using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using timeSheetApi.Models;

namespace timeSheetApi.Data
{
    public interface ICountryRepository
    {
        IList<CountryDto> GetAllCountrues();
    }
}
