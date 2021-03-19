using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using timeSheetApi.Models.Client;

namespace timeSheetApi.Data
{
    public class mockClientRepository : IClientRepository
    {
        public IList<ClientDto> clients = new List<ClientDto>();
        public mockClientRepository()
        {
            clients.Add(new ClientDto { Id = Guid.Parse("4e02ba79-776b-4c2a-b1e0-7d2e71e641c7"), Address = "Adresa 1", City = "Subotica", Country = "Serbia", CountryId = Guid.Parse("fd780814-2d8a-40bb-b31d-c1220299006c"), Name = "Vega", Postal = "24000" });
            clients.Add(new ClientDto { Id = Guid.Parse("2ae69aaa-3d6a-4c2c-a19b-0eee98440179"), Address = "Adresa 2", City = "Prijedor", Country = "Bosnia", CountryId = Guid.Parse("7572dd90-9661-41ab-bfbc-1ab00b3ae502"), Name = "Sega", Postal = "24000" });
            clients.Add(new ClientDto { Id = Guid.Parse("48c7da81-5af4-40be-a697-6710953701af"), Address = "Adresa 1", City = "Subotica", Country = "Bosnia", CountryId = Guid.Parse("7572dd90-9661-41ab-bfbc-1ab00b3ae502"), Name = "Mega", Postal = "24000" });
            clients.Add(new ClientDto { Id = Guid.Parse("664ca27c-0214-4fd5-81ea-0d045c56e302"), Address = "Adresa 4", City = "Beograd", Country = "Serbia", CountryId = Guid.Parse("fd780814-2d8a-40bb-b31d-c1220299006c"), Name = "Gega", Postal = "11000" });
          }
        public ClientDto AddClient(ClientDto client)
        {
            clients.Add(client);
            return clients.First(el=>el.Id==client.Id);
        }

        public IList<dynamic> AllClients()
        {
            List<dynamic> list = new List<dynamic>();
            foreach (var client in clients)
                list.Add(new { client.Id,client.Name });
            return list ;
        }

        public ClientDto ClientById(Guid id)
        {
            return clients.First(e => e.Id == id);
        }

        public IList<char> ClientsFirstLetter()
        {
            return clients.Select(client => client.Name.ToLower()[0]).Distinct().ToList();
        }

        public IList<ClientDto> ClientsOnPage(int page, string firstLetter, string filterText, int recordPerPage)
        {
           return clients.Where(client => client.Name[0].ToString().ToLower().Contains(firstLetter) && (client.Name.Contains(filterText) || client.Country.Contains(filterText)|| client.Address.Contains(filterText)|| client.City.Contains(filterText) || client.Postal.Contains(filterText))).Skip(page*recordPerPage).Take(recordPerPage).ToList();
        }

        public bool DeleteClient(Guid client)
        {
            clients = clients.Where((el) => el.Id != client).ToList();
                return true;
        }

        public decimal NumberOfPages( string firstLetter, string filterText, int recordPerPage)
        {
            return Math.Ceiling((decimal)clients.Where(client => client.Name[0].ToString().ToLower().Contains(firstLetter) && (client.Name.Contains(filterText) || client.Country.Contains(filterText) || client.Address.Contains(filterText) || client.City.Contains(filterText) || client.Postal.Contains(filterText))).Count()/recordPerPage);
        }

        public ClientDto UpdateClient(ClientDto client)
        {
             var current=clients.Where(el => el.Id == client.Id).FirstOrDefault();
            var index = clients.IndexOf(current);
            clients[index] = client;
            return clients[index];
        }
    }
}
