using AutoMapper;
using timeSheet.Repository.InMSSQLDB.EntitiesDB;

namespace timeSheet.Repository.InMSSQLDB.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, Contract.Entities.Client>()
                .ForMember(dest => dest.Country,
                opt => opt.MapFrom(src => src.Country.Name));
            CreateMap<Contract.Entities.Client, Client>();
        }
    }
}
