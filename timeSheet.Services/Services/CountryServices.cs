using AutoMapper;
using System.Collections.Generic;
using timeSheet.Repository.Contract.Data;
using timeSheet.Services.Contract.Models.Country;
using timeSheet.Services.Contract.Services;

namespace timeSheet.Services.Services
{
    public class CountryServices : ICountryServices
    {
        public CountryServices(ICountryRepository countryRepository)
        {
            CountryRepository = countryRepository;
            Mapper = TimeSheetMapper.Mapper;
        }

        public ICountryRepository CountryRepository { get; }
        public IMapper Mapper { get; }

        public IEnumerable<CountryDto> GetAllCountries()
        {
            return Mapper.Map<IList<CountryDto>>(CountryRepository.GetAllCountries());
        }
    }
}
