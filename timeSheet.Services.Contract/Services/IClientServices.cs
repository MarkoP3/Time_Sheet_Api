using System;
using System.Collections.Generic;
using timeSheet.Services.Contract.Models.Client;

namespace timeSheet.Services.Contract.Services
{
    public interface IClientServices
    {
        ClientConfirmationDto AddClient(ClientCreationDto client);
        ClientDto UpdateClient(ClientUpdateDto client, Guid id);
        bool DeleteClient(Guid client);
        IEnumerable<ClientDto> ClientsOnPage(int? page, string firstLetter, string filterText, int? recordPerPage);
        decimal NumberOfPages(string firstLetter, string filterText, int? recordPerPage);
        IEnumerable<char> ClientsFirstLetter();
        ClientDto ClientById(Guid id);
    }
}
