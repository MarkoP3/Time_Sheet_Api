using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using timeSheetApi.Data;
using timeSheetApi.Models.Client;

namespace timeSheetApi.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        //public IList<ClientDto> clients = new List<ClientDto>();

        public ClientController(IClientRepository clientRepository, IMapper mapper, LinkGenerator linkGenerator)
        {

            /*clients.Add(new ClientDto { Id = Guid.Parse("4e02ba79-776b-4c2a-b1e0-7d2e71e641c7"), Address = "Adresa 1", City = "Subotica", Country = "Serbia", CountryId = Guid.Parse("fd780814-2d8a-40bb-b31d-c1220299006c"), Name = "Vega", Postal = "24000" });
            clients.Add(new ClientDto { Id = Guid.Parse("2ae69aaa-3d6a-4c2c-a19b-0eee98440179"), Address = "Adresa 2", City = "Prijedor", Country = "Bosnia", CountryId = Guid.Parse("7572dd90-9661-41ab-bfbc-1ab00b3ae502"), Name = "Sega", Postal = "24000" });
            clients.Add(new ClientDto { Id = Guid.Parse("48c7da81-5af4-40be-a697-6710953701af"), Address = "Adresa 1", City = "Subotica", Country = "Bosnia", CountryId = Guid.Parse("7572dd90-9661-41ab-bfbc-1ab00b3ae502"), Name = "Mega", Postal = "24000" });
            clients.Add(new ClientDto { Id = Guid.Parse("664ca27c-0214-4fd5-81ea-0d045c56e302"), Address = "Adresa 4", City = "Beograd", Country = "Serbia", CountryId = Guid.Parse("fd780814-2d8a-40bb-b31d-c1220299006c"), Name = "Gega", Postal = "11000" });
           */ ClientRepository = clientRepository;
            Mapper = mapper;
            LinkGenerator = linkGenerator;
        }

        public IClientRepository ClientRepository { get; }
        public IMapper Mapper { get; }
        public LinkGenerator LinkGenerator { get; }

        [HttpGet("onPage")]
        public ActionResult<ClientDto> GetAllClientsOnPage(int page,string firstLetter,string filterText,int recordsPerPage)
        {
            if (firstLetter == null) firstLetter = "";
            if (filterText == null) filterText = "";
            //return Ok(clients.Where(client => client.Name[0].ToString().ToLower().Contains(firstLetter) && (client.Name.Contains(filterText) || client.Country.Contains(filterText) || client.Address.Contains(filterText) || client.City.Contains(filterText) || client.Postal.Contains(filterText))).Skip(page * recordsPerPage).Take(recordsPerPage).ToList());
            
            var clients = ClientRepository.ClientsOnPage(page, firstLetter, filterText, recordsPerPage);
            if(clients.Count>0)
            return Ok(clients);
            return NoContent();
        }
        [HttpGet("firstLetters")]
        public IActionResult GetFirstLetters()
        {
           // return Ok(clients.Select(client => client.Name.ToLower()[0]).Distinct().ToList());
            var firstLetters = ClientRepository.ClientsFirstLetter();
             if(firstLetters.Count>0)
             return Ok(firstLetters);
             return NoContent();
        }
        [HttpGet]
        public IActionResult GetAllClients()
        {
            var clients = ClientRepository.AllClients();
            if (clients.Count > 0) 
            return Ok(clients);
            return NoContent();
        }
        [HttpGet("numberOfPages")]
        public ActionResult<IList<ClientDto>> GetNumberOfPages( string firstLetter, string filterText, int recordsPerPage)
        {
            if (firstLetter == null) firstLetter = "";
            if (filterText == null) filterText = "";
            return Ok(ClientRepository.NumberOfPages(firstLetter, filterText, recordsPerPage));
        }
        [HttpPost]
        public ActionResult<ClientConfirmationDto> AddClient(ClientCreationDto client)
        {
             var createdClient = ClientRepository.AddClient(Mapper.Map<ClientDto>(client));
            string location = LinkGenerator.GetPathByAction("GetClientById", "Client", new { Id = createdClient.Id });
            if (createdClient != null)
            return Created(location,Mapper.Map<ClientConfirmationDto>(createdClient));
            return BadRequest();
        }
        [HttpGet("{id}")]
        public ActionResult<ClientDto> GetClientById(Guid id)
        {
            var client = ClientRepository.ClientById(id);
            if (client != null)
                return Ok(client);
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(Guid id)
        {
            return Ok(ClientRepository.DeleteClient(id));
        }
        [HttpPut]
        public IActionResult UpdateClient(ClientDto client)
        {
            return Ok(ClientRepository.UpdateClient(client));
        }
    }
}
