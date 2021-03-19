using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using timeSheetApi.Models.Client;

namespace timeSheetApi.Data
{
    public interface IClientRepository
    {
        ClientDto AddClient(ClientDto client);
        ClientDto UpdateClient(ClientDto client);
        bool DeleteClient(Guid client);
        IList<ClientDto> ClientsOnPage(int page, string firstLetter, string filterText, int recordPerPage);
        decimal NumberOfPages( string firstLetter, string filterText, int recordPerPage);
        IList<char> ClientsFirstLetter();
        IList<dynamic> AllClients();
        ClientDto ClientById(Guid id);
    }
}
