using AutoMapper;
using timeSheetApi.Entities;
using timeSheetApi.Models.Country;

namespace timeSheetApi.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<CountryDto, Country>();
            CreateMap<Country, CountryDto>();
        }
    }
}
