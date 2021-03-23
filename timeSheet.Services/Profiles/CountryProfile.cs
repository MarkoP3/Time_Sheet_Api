using AutoMapper;
using timeSheet.Common.Entities;
using timeSheet.Common.Models.Country;
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
