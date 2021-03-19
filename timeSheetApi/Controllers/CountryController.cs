using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using timeSheetApi.Data;
using timeSheetApi.Models;

namespace timeSheetApi.Controllers
{
    [Route("api/countries")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        public CountryController(ICountryRepository countryRepository)
        {
            CountryRepository = countryRepository;
        }

        public ICountryRepository CountryRepository { get; }

        [HttpGet]
        public ActionResult<IList<CountryDto>> GetAllCountries()
        {
            return Ok(CountryRepository.GetAllCountrues());
        }
    }
}
