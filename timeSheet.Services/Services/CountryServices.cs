using AutoMapper;
using System.Collections.Generic;
using timeSheet.Common.Models.Country;
using timeSheet.Services.Data;

namespace timeSheet.Services.Services
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
