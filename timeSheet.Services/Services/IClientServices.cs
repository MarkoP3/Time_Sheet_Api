using System;
using System.Collections.Generic;
using timeSheet.Common.Models.Client;

namespace timeSheet.Services.Services
{
    public interface IClientServices
    {
        ClientConfirmationDto AddClient(ClientCreationDto client);
        ClientDto UpdateClient(ClientUpdateDto client, Guid id);
        bool DeleteClient(Guid client);
        IList<ClientDto> ClientsOnPage(int? page, string firstLetter, string filterText, int? recordPerPage);
        decimal NumberOfPages(string firstLetter, string filterText, int? recordPerPage);
        IList<char> ClientsFirstLetter();
        IList<dynamic> AllClients();
        ClientDto ClientById(Guid id);
    }
}
