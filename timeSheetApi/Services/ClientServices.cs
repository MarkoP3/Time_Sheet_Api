using AutoMapper;
using System;
using System.Collections.Generic;
using timeSheetApi.Data;
using timeSheetApi.Entities;
using timeSheetApi.Models.Client;

namespace timeSheetApi.Services
{
    public class ClientServices : IClientServices
    {
        public ClientServices(IClientRepository clientRepository, IMapper mapper)
        {
            ClientRepository = clientRepository;
            Mapper = mapper;
        }
        public IClientRepository ClientRepository { get; }
        public IMapper Mapper { get; }

        public ClientDto AddClient(ClientCreationDto client)
        {
            return Mapper.Map<ClientDto>(ClientRepository.AddClient(Mapper.Map<Client>(client)));
        }

        public IList<dynamic> AllClients()
        {
            return ClientRepository.AllClients();
        }

        public ClientDto ClientById(Guid id)
        {
            return Mapper.Map<ClientDto>(ClientRepository.ClientById(id));
        }

        public IList<char> ClientsFirstLetter()
        {
            return ClientRepository.ClientsFirstLetter();
        }

        public IList<ClientDto> ClientsOnPage(int page, string firstLetter, string filterText, int recordPerPage)
        {
            return Mapper.Map<IList<ClientDto>>(ClientRepository.ClientsOnPage(page, firstLetter, filterText, recordPerPage));
        }

        public bool DeleteClient(Guid client)
        {
            return ClientRepository.DeleteClient(client);
        }

        public decimal NumberOfPages(string firstLetter, string filterText, int recordPerPage)
        {
            return ClientRepository.NumberOfPages(firstLetter, filterText, recordPerPage);
        }

        public ClientDto UpdateClient(ClientUpdateDto client)
        {
            return Mapper.Map<ClientDto>(ClientRepository.UpdateClient(Mapper.Map<Client>(client)));
        }
    }
}
