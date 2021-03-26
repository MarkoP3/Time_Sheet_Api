using AutoMapper;
using timeSheet.Repository.Contract.Entities;
using timeSheet.Services.Contract.Models.Country;

namespace timesheet.Services.Profiles
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
