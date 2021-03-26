using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using timeSheet.Services.Contract.Models.Project;
using timeSheet.Services.Contract.Services;

namespace timeSheetApi.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        public IProjectServices ProjectServices { get; }
        public IConfiguration Configuration { get; }
        public LinkGenerator LinkGenerator { get; }

        public ProjectController(IProjectServices projectServices, IConfiguration configuration, LinkGenerator linkGenerator)
        {
            ProjectServices = projectServices;
            Configuration = configuration;
            LinkGenerator = linkGenerator;
        }
        [HttpGet("{id}")]
        public ActionResult<ProjectDto> GetProjectByID(Guid id)
        {
            var project = ProjectServices.GetProjectByID(id);
            if (project != null)
                return Ok(project);
            return NotFound();
        }
        [HttpGet]
        public ActionResult<IList<ProjectDto>> GetAllProjectsOnPage(int? page, string firstLetter, string filterText, int? recordsPerPage)
        {
            var projects = ProjectServices.ProjectsOnPage(page, firstLetter, filterText, recordsPerPage);
            var numberOfPages = ProjectServices.NumberOfPages(firstLetter, filterText, recordsPerPage);
            if (((List<ProjectDto>)projects).Count > 0)
                return Ok(new { projects, numberOfPages });
            return NoContent();
        }
        [HttpGet("first-letters")]
        public IActionResult GetFirstLetters()
        {
            var letters = ProjectServices.ProjectsFirstLetter();
            if (((List<char>)letters).Count > 0)
                return Ok(ProjectServices.ProjectsFirstLetter());
            return NoContent();
        }
        [HttpGet("customer/{customerID}")]
        public ActionResult<IList<ProjectDto>> GetAllProjectsOfCustomer(Guid customerID)
        {
            var projects = ProjectServices.GetAllProjectsFromCustomer(customerID);
            if (((List<ProjectDto>)projects).Count > 0)
                return Ok(projects);
            return NoContent();
        }
        [HttpPost]
        public ActionResult<ProjectConfirmationDto> AddProject(ProjectCreationDto project)
        {
            var createdProject = ProjectServices.AddProject(project);
            string location = LinkGenerator.GetPathByAction("GetProjectByID", "Project", new { createdProject.Id });
            return Created(location, createdProject);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProject(Guid id)
        {
            ProjectServices.DeleteProject(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult<ProjectDto> UpdateClient(ProjectUpdateDto project, Guid id)
        {
            try
            {
                ProjectServices.UpdateProject(project, id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
