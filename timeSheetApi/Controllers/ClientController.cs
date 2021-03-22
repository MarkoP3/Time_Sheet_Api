using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using timeSheetApi.Models.Client;
using timeSheetApi.Services;

namespace timeSheetApi.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        public ClientController(IConfiguration configuration, IClientServices clientServices, IMapper mapper, LinkGenerator linkGenerator)
        {
            Configuration = configuration;
            ClientServices = clientServices;
            Mapper = mapper;
            LinkGenerator = linkGenerator;
        }

        public IConfiguration Configuration { get; }
        public IClientServices ClientServices { get; }
        public IMapper Mapper { get; }
        public LinkGenerator LinkGenerator { get; }

        [HttpGet("page/{page}")]
        public ActionResult<ClientDto> GetAllClientsOnPage(int page, string firstLetter, string filterText, int recordsPerPage)
        {
            if (firstLetter == null) firstLetter = "";
            if (filterText == null) filterText = "";
            if (recordsPerPage == 0) recordsPerPage = Convert.ToInt32(Configuration["DefaultRecordsPerPage"]);
            page -= 1;
            var clients = ClientServices.ClientsOnPage(page, firstLetter, filterText, recordsPerPage);
            if (clients.Count > 0)
                return Ok(clients);
            return NoContent();
        }
        [HttpGet("first-letters")]
        public IActionResult GetFirstLetters()
        {
            var firstLetters = ClientServices.ClientsFirstLetter();
            if (firstLetters.Count > 0)
                return Ok(firstLetters);
            return NoContent();
        }
        [HttpGet]
        public IActionResult GetAllClients()
        {
            var clients = ClientServices.AllClients();
            if (clients.Count > 0)
                return Ok(clients);
            return NoContent();
        }
        [HttpGet("number-of-pages")]
        public ActionResult<IList<ClientDto>> GetNumberOfPages(string firstLetter, string filterText, int recordsPerPage)
        {
            if (firstLetter == null) firstLetter = "";
            if (filterText == null) filterText = "";
            if (recordsPerPage == 0) recordsPerPage = Convert.ToInt32(Configuration["DefaultRecordsPerPage"]);
            return Ok(ClientServices.NumberOfPages(firstLetter, filterText, recordsPerPage));
        }
        [HttpPost]
        public ActionResult<ClientConfirmationDto> AddClient(ClientCreationDto client)
        {
            var createdClient = ClientServices.AddClient(client);
            string location = LinkGenerator.GetPathByAction("GetClientById", "Client", new { createdClient.Id });
            if (createdClient != null)
                return Created(location, Mapper.Map<ClientConfirmationDto>(createdClient));
            return BadRequest();
        }
        [HttpGet("{id}")]
        public ActionResult<ClientDto> GetClientById(Guid id)
        {
            var client = ClientServices.ClientById(id);
            if (client != null)
                return Ok(client);
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(Guid id)
        {
            return Ok(ClientServices.DeleteClient(id));
        }
        [HttpPut]
        public IActionResult UpdateClient(ClientUpdateDto client)
        {
            return Ok(ClientServices.UpdateClient(client));
        }
    }
}
