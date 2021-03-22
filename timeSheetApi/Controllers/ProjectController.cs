using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using timeSheetApi.Models.Project;
using timeSheetApi.Services;

namespace timeSheetApi.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        public IProjectServices ProjectServices { get; }
        public IConfiguration Configuration { get; }
        public IMapper Mapper { get; }
        public LinkGenerator LinkGenerator { get; }

        public ProjectController(IProjectServices projectServices, IConfiguration configuration, IMapper mapper, LinkGenerator linkGenerator)
        {
            ProjectServices = projectServices;
            Configuration = configuration;
            Mapper = mapper;
            LinkGenerator = linkGenerator;
        }
        [HttpGet("{id}")]
        public ActionResult<ProjectDto> GetProjectByID(Guid id)
        {
            return Ok(ProjectServices.GetProjectByID(id));
        }
        [HttpGet("page/{page}")]
        public ActionResult<IList<ProjectDto>> GetAllProjectsOnPage(int page, string firstLetter, string filterText, int recordsPerPage)
        {
            if (firstLetter == null) firstLetter = "";
            if (filterText == null) filterText = "";
            if (recordsPerPage == 0) recordsPerPage = Convert.ToInt32(Configuration["DefaultRecordsPerPage"]);
            var projects = ProjectServices.ProjectsOnPage(page, firstLetter, filterText, recordsPerPage);
            if (projects.Count > 0)
                return Ok(projects);
            return NoContent();
        }
        [HttpGet("first-letters")]
        public IActionResult GetFirstLetters()
        {
            return Ok(ProjectServices.ProjectsFirstLetter());
        }
        [HttpGet]
        public IActionResult GetAllClients()
        {
            return Ok(ProjectServices.AllProjects());
        }
        [HttpGet("customer/{customerID}")]
        public ActionResult<IList<ProjectDto>> GetAllProjectsOfCustomer(Guid customerID)
        {
            return Ok(ProjectServices.GetAllProjectsFromCustomer(customerID));
        }
        [HttpGet("number-of-pages")]
        public IActionResult GetNumberOfPages(string firstLetter, string filterText, int recordsPerPage)
        {
            if (firstLetter == null) firstLetter = "";
            if (filterText == null) filterText = "";
            if (recordsPerPage == 0) recordsPerPage = Convert.ToInt32(Configuration["DefaultRecordsPerPage"]);
            return Ok(ProjectServices.NumberOfPages(firstLetter, filterText, recordsPerPage));
        }
        [HttpPost]
        public ActionResult<ProjectConfirmationDto> AddProject(ProjectCreationDto project)
        {
            var createdProject = ProjectServices.AddProject(project);
            string location = LinkGenerator.GetPathByAction("GetProjectByID", "Project", new { createdProject.Id });
            if (createdProject != null)
                return Created(location, Mapper.Map<ProjectConfirmationDto>(createdProject));
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProject(Guid id)
        {
            return Ok(ProjectServices.DeleteProject(id));
        }
        [HttpPut]
        public ActionResult<ProjectDto> UpdateClient(ProjectUpdateDto project)
        {
            return Ok(ProjectServices.UpdateProject(project));
        }
    }
}
