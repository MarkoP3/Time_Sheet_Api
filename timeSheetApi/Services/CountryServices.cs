using AutoMapper;
using System.Collections.Generic;
using timeSheetApi.Data;
using timeSheetApi.Models.Country;

namespace timeSheetApi.Services
{
    public class CountryServices : ICountryServices
    {
        public CountryServices(ICountryRepository countryRepository, IMapper mapper)
        {
            CountryRepository = countryRepository;
            Mapper = mapper;
        }

        public ICountryRepository CountryRepository { get; }
        public IMapper Mapper { get; }

        public IList<CountryDto> GetAllCountries()
        {
            return Mapper.Map<IList<CountryDto>>(CountryRepository.GetAllCountries());
        }
    }
}
