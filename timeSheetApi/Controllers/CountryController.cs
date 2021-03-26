using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using timeSheet.Services.Contract.Models.Country;
using timeSheet.Services.Contract.Services;

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
