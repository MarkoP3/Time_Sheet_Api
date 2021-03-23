using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using timeSheet.Common.Entities;
using timeSheet.Common.Models.Client;
using timeSheet.Services.Data;

namespace timeSheet.Services.Services
{
    public class ClientServices : IClientServices
    {

        public static IList<Client> clients = new List<Client>();
        static ClientServices()
        {
            clients.Add(new Client { Id = Guid.Parse("4e02ba79-776b-4c2a-b1e0-7d2e71e641c7"), Address = "Adresa 1", City = "Subotica", Country = "Serbia", CountryId = Guid.Parse("fd780814-2d8a-40bb-b31d-c1220299006c"), Name = "Vega", Postal = "24000" });
            clients.Add(new Client { Id = Guid.Parse("2ae69aaa-3d6a-4c2c-a19b-0eee98440179"), Address = "Adresa 2", City = "Prijedor", Country = "Bosnia", CountryId = Guid.Parse("7572dd90-9661-41ab-bfbc-1ab00b3ae502"), Name = "Sega", Postal = "24000" });
            clients.Add(new Client { Id = Guid.Parse("48c7da81-5af4-40be-a697-6710953701af"), Address = "Adresa 1", City = "Subotica", Country = "Bosnia", CountryId = Guid.Parse("7572dd90-9661-41ab-bfbc-1ab00b3ae502"), Name = "Mega", Postal = "24000" });
            clients.Add(new Client { Id = Guid.Parse("664ca27c-0214-4fd5-81ea-0d045c56e302"), Address = "Adresa 4", City = "Beograd", Country = "Serbia", CountryId = Guid.Parse("fd780814-2d8a-40bb-b31d-c1220299006c"), Name = "Gega", Postal = "11000" });

        }

        public ClientServices(IClientRepository clientRepository, IMapper mapper)
        {
            ClientRepository = clientRepository;
            Mapper = TimeSheetMapper.Mapper;


        }
        public IClientRepository ClientRepository { get; }
        public IMapper Mapper { get; }

        public ClientConfirmationDto AddClient(ClientCreationDto client)
        {
            //return Mapper.Map<ClientDto>(ClientRepository.AddClient(Mapper.Map<Client>(client)));
            return Mapper.Map<ClientConfirmationDto>(mockAddClient(Mapper.Map<Client>(client)));
        }

        public IList<dynamic> AllClients()
        {
            return mockAllClients();
            // return ClientRepository.AllClients();
        }

        public ClientDto ClientById(Guid id)
        {
            //return Mapper.Map<ClientDto>(ClientRepository.ClientById(id));
            return Mapper.Map<ClientDto>(mockClientById(id));
        }

        public IList<char> ClientsFirstLetter()
        {
            return mockClientsFirstLetter();
            // return ClientRepository.ClientsFirstLetter();
        }

        public IList<ClientDto> ClientsOnPage(int? page, string firstLetter, string filterText, int? recordPerPage)
        {
            if (firstLetter == null) firstLetter = "";
            if (filterText == null) filterText = "";
            if (recordPerPage == null) recordPerPage = 3;
            if (page == null || page <= 0)
            {
                //recordPerPage = ClientRepository.AllClients().Count;
                recordPerPage = mockAllClients().Count;
            }
            else
            {
                page -= 1;
            }
            //return Mapper.Map<IList<ClientDto>>(ClientRepository.ClientsOnPage(page, firstLetter, filterText, recordPerPage));
            return Mapper.Map<IList<ClientDto>>(mockClientsOnPage((int)page, firstLetter, filterText, (int)recordPerPage));
        }

        public bool DeleteClient(Guid client)
        {
            //ClientRepository.DeleteClient(client);
            try
            {

                mockDeleteClient(client);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public decimal NumberOfPages(string firstLetter, string filterText, int? recordPerPage)
        {
            if (firstLetter == null) firstLetter = "";
            if (filterText == null) filterText = "";
            if (recordPerPage == null) recordPerPage = 3;
            //return ClientRepository.NumberOfPages(firstLetter, filterText, recordPerPage);
            return mockNumberOfPages(firstLetter, filterText, (int)recordPerPage);
        }

        public ClientDto UpdateClient(ClientUpdateDto client, Guid id)
        {
            if (mockClientById(id) == null)
                throw new KeyNotFoundException();
            var clientEntity = Mapper.Map<Client>(client);
            clientEntity.Id = id;
            // return Mapper.Map<ClientDto>(ClientRepository.UpdateClient(Mapper.Map<Client>(client)));
            return Mapper.Map<ClientDto>(mockUpdateClient(clientEntity));
        }




        public Client mockAddClient(Client client)
        {
            clients.Add(client);
            return clients.First(el => el.Id == client.Id);
        }

        public IList<dynamic> mockAllClients()
        {
            List<dynamic> list = new List<dynamic>();
            foreach (var client in clients)
                list.Add(new { client.Id, client.Name });
            return list;
        }

        public Client mockClientById(Guid id)
        {
            return clients.FirstOrDefault(e => e.Id == id);
        }

        public IList<char> mockClientsFirstLetter()
        {
            return clients.Select(client => client.Name.ToLower()[0]).Distinct().ToList();
        }

        public IList<Client> mockClientsOnPage(int page, string firstLetter, string filterText, int recordPerPage)
        {
            return clients.Where(client => client.Name[0].ToString().ToLower().Contains(firstLetter) && (client.Name.Contains(filterText) || client.Country.Contains(filterText) || client.Address.Contains(filterText) || client.City.Contains(filterText) || client.Postal.Contains(filterText))).Skip(page * recordPerPage).Take(recordPerPage).ToList();
        }

        public void mockDeleteClient(Guid client)
        {
            clients = clients.Where((el) => el.Id != client).ToList();
        }

        public decimal mockNumberOfPages(string firstLetter, string filterText, int recordPerPage)
        {
            return Math.Ceiling((decimal)clients.Where(client => client.Name[0].ToString().ToLower().Contains(firstLetter) && (client.Name.Contains(filterText) || client.Country.Contains(filterText) || client.Address.Contains(filterText) || client.City.Contains(filterText) || client.Postal.Contains(filterText))).Count() / recordPerPage);
        }

        public Client mockUpdateClient(Client client)
        {
            var current = clients.Where(el => el.Id == client.Id).FirstOrDefault();
            var index = clients.IndexOf(current);
            clients[index] = client;
            return clients[index];
        }
    }
}
