using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using timeSheet.Common.Models;
using timeSheet.Services.Data;

namespace timeSheetApi.Controllers
{
    [Route("api/team-members")]
    [ApiController]
    public class TeamMemberController : ControllerBase
    {
        public ITeamMemberRepository TeamMemberRepository { get; }
        public IConfiguration Configuration { get; }

        public TeamMemberController(ITeamMemberRepository teamMemberRepository, IConfiguration configuration)
        {
            TeamMemberRepository = teamMemberRepository;
            Configuration = configuration;
        }
        [HttpGet("page/{page}")]
        public IActionResult GetAllTeamMembersOnPage(int page, int recordsPerPage)
        {
            if (recordsPerPage == 0) recordsPerPage = Convert.ToInt32(Configuration["DefaultRecordsPerPage"]);
            var teamMembers = TeamMemberRepository.TeamMembersOnPage(page, recordsPerPage);
            if (teamMembers.Count > 0)
                return Ok(teamMembers);
            return NoContent();
        }
        [HttpGet]
        public IActionResult GetAllTeamMembers()
        {
            return Ok(TeamMemberRepository.AllTeamMembers());
        }
        [HttpGet("number-of-pages")]
        public IActionResult GetNumberOfPages(int recordsPerPage)
        {
            return Ok(TeamMemberRepository.NumberOfPages(recordsPerPage));
        }
        [HttpPost]
        public IActionResult AddTeamMember(TeamMemberDto teamMember)
        {
            return Ok(TeamMemberRepository.AddTeamMember(teamMember));
        }
        [HttpGet("{id}/hours-per-day")]
        public IActionResult GetMembersMaxHoursPerDay(Guid id)
        {
            return Ok(TeamMemberRepository.MembersMaxHoursPerDay(id));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTeamMember(Guid id)
        {
            return Ok(TeamMemberRepository.DeleteTeamMemeber(id));
        }
        [HttpPut]
        public IActionResult UpdateTeamMember(TeamMemberDto teamMember)
        {
            return Ok(TeamMemberRepository.UpdateTeamMember(teamMember));
        }
    }
}
