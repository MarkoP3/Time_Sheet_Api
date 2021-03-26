using System;
using System.Collections.Generic;
using System.Linq;
using timeSheet.Repository.Contract.Data;
using timeSheet.Repository.Contract.Entities;

namespace timeSheet.Repository.Data
{
    public class mockClientRepository : IClientRepository
    {
        public IList<Client> clients = new List<Client>();
        public mockClientRepository()
        {
            clients.Add(new Client(Guid.Parse("4e02ba79-776b-4c2a-b1e0-7d2e71e641c7"), Guid.Parse("fd780814-2d8a-40bb-b31d-c1220299006c"), "Vega", "Adresa 1", "Subotica", "24000", "Serbia"));
            clients.Add(new Client(Guid.Parse("2ae69aaa-3d6a-4c2c-a19b-0eee98440179"), Guid.Parse("7572dd90-9661-41ab-bfbc-1ab00b3ae502"), "Sega", "Adresa 2", "Prijedor", "24000", "Bosnia"));
            clients.Add(new Client(Guid.Parse("48c7da81-5af4-40be-a697-6710953701af"), Guid.Parse("7572dd90-9661-41ab-bfbc-1ab00b3ae502"), "Mega", "Adresa 1", "Subotica", "24000", "Bosnia"));
            clients.Add(new Client(Guid.Parse("664ca27c-0214-4fd5-81ea-0d045c56e302"), Guid.Parse("fd780814-2d8a-40bb-b31d-c1220299006c"), "Gega", "Adresa 4", "Beograd", "11000", "Serbia"));
        }
        public Client AddClient(Client client)
        {
            clients.Add(client);
            return clients.First(el => el.Id == client.Id);
        }

        public IEnumerable<Client> AllClients()
        {

            return clients;
        }

        public Client ClientById(Guid id)
        {
            return clients.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<char> ClientsFirstLetter()
        {
            return clients.Select(client => client.Name.ToLower()[0]).Distinct().ToList();
        }

        public IEnumerable<Client> ClientsOnPage(int page, string firstLetter, string filterText, int recordPerPage)
        {
            return clients.Where(client => client.Name[0].ToString().ToLower().Contains(firstLetter) && (client.Name.Contains(filterText) || client.Country.Contains(filterText) || client.Address.Contains(filterText) || client.City.Contains(filterText) || client.Postal.Contains(filterText))).Skip(page * recordPerPage).Take(recordPerPage).ToList();
        }

        public bool DeleteClient(Guid client)
        {
            var deletingClient = ClientById(client);
            if (deletingClient == null)
                return false;
            else
                clients = clients.Where((el) => el.Id != client).ToList();
            return true;
        }

        public decimal NumberOfPages(string firstLetter, string filterText, int recordPerPage)
        {
            return Math.Ceiling((decimal)clients.Where(client => client.Name[0].ToString().ToLower().Contains(firstLetter) && (client.Name.Contains(filterText) || client.Country.Contains(filterText) || client.Address.Contains(filterText) || client.City.Contains(filterText) || client.Postal.Contains(filterText))).Count() / recordPerPage);
        }

        public Client UpdateClient(Client client)
        {
            if (ClientById(client.Id) == null)
                throw new KeyNotFoundException();
            var current = clients.Where(el => el.Id == client.Id).FirstOrDefault();
            var index = clients.IndexOf(current);
            clients[index] = client;
            return clients[index];
        }
    }
}
