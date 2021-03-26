using AutoMapper;
using timeSheet.Repository.InMSSQLDB.EntitiesDB;

namespace timeSheet.Repository.InMSSQLDB.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, Contract.Entities.Country>();
        }
    }
}
