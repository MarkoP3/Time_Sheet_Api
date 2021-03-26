using System;
using System.Collections.Generic;
using timeSheet.Repository.Contract.Entities;

namespace timeSheet.Repository.Contract.Data
{
    public interface IClientRepository
    {
        Client AddClient(Client client);
        Client UpdateClient(Client client);
        bool DeleteClient(Guid client);
        IEnumerable<Client> ClientsOnPage(int page, string firstLetter, string filterText, int recordPerPage);
        decimal NumberOfPages(string firstLetter, string filterText, int recordPerPage);
        IEnumerable<char> ClientsFirstLetter();
        IEnumerable<Client> AllClients();
        Client ClientById(Guid id);

    }
}
