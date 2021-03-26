using AutoMapper;
using System;
using System.Collections.Generic;
using timeSheet.Repository.Contract.Data;
using timeSheet.Repository.Contract.Entities;
using timeSheet.Services.Contract.Models.Client;
using timeSheet.Services.Contract.Services;

namespace timeSheet.Services.Services
{
    public class ClientServices : IClientServices
    {

        public ClientServices(IClientRepository clientRepository)
        {
            ClientRepository = clientRepository;
            Mapper = TimeSheetMapper.Mapper;


        }
        public IClientRepository ClientRepository { get; }
        public IMapper Mapper { get; }

        public ClientConfirmationDto AddClient(ClientCreationDto client)
        {
            var addedClient = ClientRepository.AddClient(new Client(Guid.NewGuid(), client.CountryId, client.Name, client.Address, client.City, client.Postal, client.Country));
            return Mapper.Map<ClientConfirmationDto>(addedClient);
        }

        public ClientDto ClientById(Guid id)
        {
            return Mapper.Map<ClientDto>(ClientRepository.ClientById(id));

        }

        public IEnumerable<char> ClientsFirstLetter()
        {

            return ClientRepository.ClientsFirstLetter();
        }

        public IEnumerable<ClientDto> ClientsOnPage(int? page, string firstLetter, string filterText, int? recordPerPage)
        {
            if (firstLetter == null) firstLetter = "";
            if (filterText == null) filterText = "";
            if (recordPerPage == null || recordPerPage <= 0) recordPerPage = 3;
            if (page == null || page <= 0)
            {
                recordPerPage = ((List<Client>)ClientRepository.AllClients()).Count;
                page = 0;
            }
            else
            {
                page -= 1;
            }
            return Mapper.Map<IList<ClientDto>>(ClientRepository.ClientsOnPage((int)page, firstLetter, filterText, (int)recordPerPage));
        }

        public bool DeleteClient(Guid client)
        {
            var isDeleted = ClientRepository.DeleteClient(client);
            return isDeleted;


        }

        public decimal NumberOfPages(string firstLetter, string filterText, int? recordPerPage)
        {
            if (firstLetter == null) firstLetter = "";
            if (filterText == null) filterText = "";
            if (recordPerPage == null || recordPerPage <= 0) recordPerPage = 3;
            return ClientRepository.NumberOfPages(firstLetter, filterText, (int)recordPerPage);
        }

        public ClientDto UpdateClient(ClientUpdateDto client, Guid id)
        {
            var updatedClient = ClientRepository.UpdateClient(new Client(id, client.CountryId, client.Name, client.Address, client.City, client.Postal, client.Country));
            return Mapper.Map<ClientDto>(updatedClient);
        }

    }
}
