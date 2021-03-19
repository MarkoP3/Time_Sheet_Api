using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using timeSheetApi.Models.Client;

namespace timeSheetApi.Profiles
{
    public class ClientProfile :Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientCreationDto,ClientDto>()
                .ForMember(
                d=>d.Id,
                o=>o.MapFrom(src=>Guid.NewGuid()));
            CreateMap<ClientUpdateDto, ClientDto>();
            CreateMap<ClientDto, ClientConfirmationDto>();
        }
    }
}
