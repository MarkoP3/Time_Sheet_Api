using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using timeSheet.Services.Contract.Models;
using timeSheet.Services.Contract.Services;

namespace timeSheetApi.Controllers
{
    [Route("api/team-members")]
    [ApiController]
    public class TeamMemberController : ControllerBase
    {
        public ITeamMemberServices TeamMemberService { get; }
        public IConfiguration Configuration { get; }
        public IMapper Mapper { get; }

        public TeamMemberController(ITeamMemberServices teamMemberService, IConfiguration configuration, IMapper mapper)
        {
            TeamMemberService = teamMemberService;
            Configuration = configuration;
            Mapper = mapper;
        }
        [HttpGet("page/{page}")]
        public IActionResult GetAllTeamMembersOnPage(int page, int recordsPerPage)
        {
            if (recordsPerPage == 0) recordsPerPage = Convert.ToInt32(Configuration["DefaultRecordsPerPage"]);
            var teamMembers = TeamMemberService.TeamMembersOnPage(page, recordsPerPage);
            if (((List<TeamMemberDto>)teamMembers).Count > 0)
                return Ok(teamMembers);
            return NoContent();
        }
        [HttpGet]
        public IActionResult GetAllTeamMembers()
        {
            return Ok(TeamMemberService.AllTeamMembers());
        }
        [HttpGet("number-of-pages")]
        public IActionResult GetNumberOfPages(int recordsPerPage)
        {
            return Ok(TeamMemberService.NumberOfPages(recordsPerPage));
        }
        [HttpPost]
        public IActionResult AddTeamMember(TeamMemberDto teamMember)
        {
            return Ok(TeamMemberService.AddTeamMember(teamMember));
        }
        [HttpGet("{id}/hours-per-day")]
        public IActionResult GetMembersMaxHoursPerDay(Guid id)
        {
            try
            {
                return Ok(TeamMemberService.MembersMaxHoursPerDay(id));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTeamMember(Guid id)
        {
            return Ok(TeamMemberService.DeleteTeamMemeber(id));
        }
        [HttpPut]
        public IActionResult UpdateTeamMember(TeamMemberDto teamMember)
        {
            return Ok(TeamMemberService.UpdateTeamMember(teamMember));
        }
    }
}
