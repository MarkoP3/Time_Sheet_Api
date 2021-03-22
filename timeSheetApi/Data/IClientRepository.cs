using System;
using System.Collections.Generic;
using timeSheetApi.Entities;

namespace timeSheetApi.Data
{
    public interface IClientRepository
    {
        Client AddClient(Client client);
        Client UpdateClient(Client client);
        bool DeleteClient(Guid client);
        IList<Client> ClientsOnPage(int page, string firstLetter, string filterText, int recordPerPage);
        decimal NumberOfPages(string firstLetter, string filterText, int recordPerPage);
        IList<char> ClientsFirstLetter();
        IList<dynamic> AllClients();
        Client ClientById(Guid id);
    }
}
