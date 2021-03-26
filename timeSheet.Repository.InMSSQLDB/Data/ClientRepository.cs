using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using timeSheet.Repository.Contract.Data;
using timeSheet.Repository.InMSSQLDB.EntitiesDB;

namespace timeSheet.Repository.InMSSQLDB.Data
{
    public class ClientRepository : IClientRepository
    {
        public ClientRepository(TimeSheetContext context, IMapper mapper)
        {
            Context = context;
            Mapper = TimeSheetDBMapper.Mapper;
        }

        public TimeSheetContext Context { get; }
        public IMapper Mapper { get; }

        public Contract.Entities.Client AddClient(Contract.Entities.Client client)
        {
            var created = Context.Add(new Client() { Id = client.Id, Name = client.Name, City = client.City, Address = client.Address, CountryId = client.CountryId, Postal = client.Postal });
            Context.SaveChanges();
            return Mapper.Map<Contract.Entities.Client>(created.Entity);
        }

        public IEnumerable<Contract.Entities.Client> AllClients()
        {
            return Mapper.Map<IList<Contract.Entities.Client>>(Context.Clients.ToList());
        }

        public Contract.Entities.Client ClientById(Guid id)
        {
            return Mapper.Map<Contract.Entities.Client>(Context.Clients.Where(e => e.Id == id).FirstOrDefault());
        }

        public IEnumerable<char> ClientsFirstLetter()
        {
            return Context.Clients.Select(client => client.Name.ToLower()[0]).Distinct().ToList();
        }

        public IEnumerable<Contract.Entities.Client> ClientsOnPage(int page, string firstLetter, string filterText, int recordPerPage)
        {
            var clients = Context.Clients.Include(blog => blog.Country).ToList().Where(client => client.Name[0].ToString().ToLower().Contains(firstLetter) && (client.Name.Contains(filterText) || client.Country.Name.Contains(filterText) || client.Address.Contains(filterText) || client.City.Contains(filterText) || client.Postal.Contains(filterText))).Skip(page * recordPerPage).Take(recordPerPage).ToList();

            return Mapper.Map<IList<Contract.Entities.Client>>(clients);
        }

        public bool DeleteClient(Guid client)
        {
            var deletingClient = Context.Clients.Where(e => e.Id == client).FirstOrDefault();
            if (deletingClient == null)
                return false;
            else
            {
                Context.Remove(deletingClient);
                Context.SaveChanges();
            }
            return true;

        }

        public decimal NumberOfPages(string firstLetter, string filterText, int recordPerPage)
        {
            return Math.Ceiling((decimal)Context.Clients.ToList().Where(client => client.Name[0].ToString().ToLower().Contains(firstLetter) && (client.Name.Contains(filterText) || client.Country.Name.Contains(filterText) || client.Address.Contains(filterText) || client.City.Contains(filterText) || client.Postal.Contains(filterText))).Count() / recordPerPage);
        }


        public Contract.Entities.Client UpdateClient(Contract.Entities.Client client)
        {
            var updatedClient = Context.Clients.FirstOrDefault(e => e.Id == client.Id);
            if (updatedClient == null)
                throw new ValidationException();
            updatedClient.Name = client.Name;
            updatedClient.Postal = client.Postal;
            updatedClient.Address = client.Address;
            updatedClient.City = client.City;
            updatedClient.CountryId = client.CountryId;
            Context.SaveChanges();
            return Mapper.Map<Contract.Entities.Client>(updatedClient);
        }
    }
}
