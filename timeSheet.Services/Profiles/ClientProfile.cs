using AutoMapper;
using System;
using timeSheet.Repository.Contract.Entities;
using timeSheet.Services.Contract.Models.Client;

namespace timesheet.Services.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientCreationDto, Client>()
                .ForMember(
                d => d.Id,
                o => o.MapFrom(src => Guid.NewGuid()))
                .ForAllMembers(opt => opt.Condition(e => e.Name != null));
            CreateMap<ClientUpdateDto, Client>();
            CreateMap<Client, ClientDto>();
            CreateMap<Client, ClientConfirmationDto>();
            CreateMap<ClientDto, ClientConfirmationDto>();
            CreateMap<ClientDto, Client>();
            CreateMap<ClientUpdateDto, Client>();
        }
    }
}
