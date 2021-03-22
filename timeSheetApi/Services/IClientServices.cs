using System;
using System.Collections.Generic;
using timeSheetApi.Models.Client;

namespace timeSheetApi.Services
{
    public interface IClientServices
    {
        ClientDto AddClient(ClientCreationDto client);
        ClientDto UpdateClient(ClientUpdateDto client);
        bool DeleteClient(Guid client);
        IList<ClientDto> ClientsOnPage(int page, string firstLetter, string filterText, int recordPerPage);
        decimal NumberOfPages(string firstLetter, string filterText, int recordPerPage);
        IList<char> ClientsFirstLetter();
        IList<dynamic> AllClients();
        ClientDto ClientById(Guid id);
    }
}
