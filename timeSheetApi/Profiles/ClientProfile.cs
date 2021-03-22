using AutoMapper;
using System;
using timeSheetApi.Entities;
using timeSheetApi.Models.Client;

namespace timeSheetApi.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientCreationDto, Client>()
                .ForMember(
                d => d.Id,
                o => o.MapFrom(src => Guid.NewGuid()));
            CreateMap<ClientUpdateDto, Client>();
            CreateMap<Client, ClientDto>();
            CreateMap<Client, ClientConfirmationDto>();
            CreateMap<ClientDto, ClientConfirmationDto>();
        }
    }
}
