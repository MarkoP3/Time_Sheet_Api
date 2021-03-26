using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using timeSheet.Services.Contract.Models.Client;
using timeSheet.Services.Contract.Services;

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

        [HttpGet("first-letters")]
        public IActionResult GetFirstLetters()
        {
            var firstLetters = ClientServices.ClientsFirstLetter();
            if (((List<char>)firstLetters).Count > 0)
                return Ok(firstLetters);
            return NoContent();
        }
        [HttpGet]
        public ActionResult<IList<ClientDto>> GetClients(int? page, string firstLetter, string filterText, int? recordsPerPage)
        {
            var clients = ClientServices.ClientsOnPage(page, firstLetter, filterText, recordsPerPage);
            var numberOfPages = ClientServices.NumberOfPages(firstLetter, filterText, recordsPerPage);
            if (((List<ClientDto>)clients).Count > 0)
                return Ok(new { clients, numberOfPages });
            return NoContent();
        }
        [HttpPost]
        public ActionResult<ClientConfirmationDto> AddClient(ClientCreationDto client)
        {
            try
            {
                var createdClient = ClientServices.AddClient(client);
                string location = LinkGenerator.GetPathByAction("GetClientById", "Client", new { createdClient.Id });
                return Created(location, createdClient);
            }
            catch (ValidationException)
            {
                return BadRequest();
            }
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
            ClientServices.DeleteClient(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateClient(ClientUpdateDto updateClient, Guid id)
        {
            try
            {
                ClientServices.UpdateClient(updateClient, id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (ValidationException)
            {
                return BadRequest();
            }
        }
    }
}
