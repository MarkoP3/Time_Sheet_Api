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
    [Route("api/teamMembers")]
    [ApiController]
    public class TeamMemberController : ControllerBase
    {
        public ITeamMemberRepository TeamMemberRepository { get; }

        public TeamMemberController(ITeamMemberRepository teamMemberRepository)
        {
            TeamMemberRepository = teamMemberRepository;
        }
        [HttpGet("onPage")]
        public IActionResult GetAllTeamMembersOnPage(int page, int recordsPerPage)
        {
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
        [HttpGet("numberOfPages")]
        public IActionResult GetNumberOfPages(int recordsPerPage)
        {
            return Ok(TeamMemberRepository.NumberOfPages(recordsPerPage));
        }
        [HttpPost]
        public IActionResult AddTeamMember(TeamMemberDto teamMember)
        {
            return Ok(TeamMemberRepository.AddTeamMember(teamMember));
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
