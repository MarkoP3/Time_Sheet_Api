using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using timeSheetApi.Data;
using timeSheetApi.Models;

namespace timeSheetApi.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        public IProjectRepository ProjectRepository { get; }

        public ProjectController(IProjectRepository projectRepository)
        {
            ProjectRepository = projectRepository;
        }

        [HttpGet("onPage")]
        public IActionResult GetAllProjectsOnPage(int page, string firstLetter, string filterText, int recordsPerPage)
        {
            if (firstLetter == null) firstLetter = "";
            if (filterText == null) filterText = "";
            var projects = ProjectRepository.ProjectsOnPage(page, firstLetter, filterText, recordsPerPage);
            if (projects.Count > 0)
                return Ok(projects);
            return NoContent();
        }
        [HttpGet("firstLetters")]
        public IActionResult GetFirstLetters()
        {
            return Ok(ProjectRepository.ProjectsFirstLetter());
        }
        [HttpGet]
        public IActionResult GetAllClients()
        {
            return Ok(ProjectRepository.AllProjects());
        }
        [HttpGet("numberOfPages")]
        public IActionResult GetNumberOfPages(string firstLetter, string filterText, int recordsPerPage)
        {
            if (firstLetter == null) firstLetter = "";
            if (filterText == null) filterText = "";
            return Ok(ProjectRepository.NumberOfPages(firstLetter, filterText, recordsPerPage));
        }
        [HttpPost]
        public IActionResult AddProject(ProjectDto project)
        {
            return Ok(ProjectRepository.AddProject(project));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProject(Guid id)
        {
            return Ok(ProjectRepository.DeleteProject(id));
        }
        [HttpPut]
        public IActionResult UpdateClient(ProjectDto project)
        {
            return Ok(ProjectRepository.UpdateProject(project));
        }
    }
}
