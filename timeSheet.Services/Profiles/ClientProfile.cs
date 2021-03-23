using AutoMapper;
using System;
using timeSheet.Common.Entities;
using timeSheet.Common.Models.Client;

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
            CreateMap<ClientDto, Client>();
            CreateMap<ClientUpdateDto, Client>();
        }
    }
}
