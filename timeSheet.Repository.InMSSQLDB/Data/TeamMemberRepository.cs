using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using timeSheet.Repository.Contract.Data;
using timeSheet.Repository.InMSSQLDB.EntitiesDB;

namespace timeSheet.Repository.InMSSQLDB.Data
{
    public class TeamMemberRepository : ITeamMemberRepository
    {
        public TeamMemberRepository(TimeSheetContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public TimeSheetContext Context { get; }
        public IMapper Mapper { get; }

        public Contract.Entities.TeamMember AddTeamMember(Contract.Entities.TeamMember teamMember)
        {
            var created = Context.Add(new TeamMember() { Email = teamMember.Email, HoursPerWeek = teamMember.HoursPerWeek, Id = teamMember.Id, Name = teamMember.Name, Password = "sifra", Role = teamMember.Role, Status = teamMember.Status, Salt = "random salt", Username = teamMember.Username });
            return Mapper.Map<Contract.Entities.TeamMember>(created.Entity);
        }

        public IList<Contract.Entities.TeamMember> AllTeamMembers()
        {
            return Mapper.Map<IList<Contract.Entities.TeamMember>>(Context.TeamMembers.ToList());
        }

        public bool DeleteTeamMemeber(Guid teamMember)
        {
            var deletingTeamMember = Context.TeamMembers.Where(e => e.Id == teamMember).FirstOrDefault();
            if (deletingTeamMember == null)
                return false;
            else
            {
                Context.Remove(deletingTeamMember);
            }
            return true;
        }

        public decimal MembersMaxHoursPerDay(Guid id)
        {
            if (Context.TeamMembers.FirstOrDefault(e => e.Id == id) == null)
                throw new KeyNotFoundException();
            return Context.TeamMembers.FirstOrDefault(e => e.Id == id).HoursPerWeek;
        }

        public decimal NumberOfPages(int recordPerPage)
        {
            return Math.Ceiling((decimal)Context.TeamMembers.Count() / recordPerPage);
        }

        public bool SaveChanges()
        {
            return Context.SaveChanges() > 0;
        }

        public IList<Contract.Entities.TeamMember> TeamMembersOnPage(int page, int recordPerPage)
        {
            return Mapper.Map<IList<Contract.Entities.TeamMember>>(Context.TeamMembers.ToList().Skip(page * recordPerPage).Take(recordPerPage).ToList());
        }

        public Contract.Entities.TeamMember UpdateTeamMember(Contract.Entities.TeamMember teamMember)
        {
            var updateMember = Context.TeamMembers.FirstOrDefault(e => e.Id == teamMember.Id);
            if (updateMember == null)
                throw new ValidationException();
            updateMember.Email = teamMember.Email;
            updateMember.HoursPerWeek = teamMember.HoursPerWeek;
            updateMember.Name = teamMember.Name;
            updateMember.Role = teamMember.Role;
            updateMember.Status = teamMember.Status;
            updateMember.Username = teamMember.Username;
            return Mapper.Map<Contract.Entities.TeamMember>(updateMember);
        }
    }
}
