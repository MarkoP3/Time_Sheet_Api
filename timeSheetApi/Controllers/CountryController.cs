using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using timeSheetApi.Models.Country;
using timeSheetApi.Services;

namespace timeSheetApi.Controllers
{
    [Route("api/countries")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        public CountryController(ICountryServices countryServices)
        {
            CountrySerivces = countryServices;
        }

        public ICountryServices CountrySerivces { get; }

        [HttpGet]
        public ActionResult<IList<CountryDto>> GetAllCountries()
        {
            return Ok(CountrySerivces.GetAllCountries());
        }
    }
}
