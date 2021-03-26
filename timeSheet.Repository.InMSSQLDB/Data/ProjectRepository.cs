using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using timeSheet.Repository.Contract.Data;
using timeSheet.Repository.InMSSQLDB.EntitiesDB;

namespace timeSheet.Repository.InMSSQLDB.Data
{
    public class ProjectRepository : IProjectRepository
    {
        public ProjectRepository(TimeSheetContext context, IMapper mapper)
        {
            Context = context;
            Mapper = TimeSheetDBMapper.Mapper;
        }

        public TimeSheetContext Context { get; }
        public IMapper Mapper { get; }

        public Contract.Entities.Project AddProject(Contract.Entities.Project project)
        {
            var created = Context.Add(new Project() { ClientId = project.ClientId, Description = project.Description, Id = project.Id, LeadId = project.LeadId, Name = project.Name, Status = project.Status });
            return Mapper.Map<Contract.Entities.Project>(created.Entity);
        }

        public IList<Contract.Entities.Project> AllProjects()
        {
            return Mapper.Map<IList<Contract.Entities.Project>>(Context.Projects.ToList());
        }

        public bool DeleteProject(Guid project)
        {
            var deletingProject = Context.Projects.FirstOrDefault(e => e.Id == project);
            if (project == null)
                return false;
            else
            {
                Context.Remove(deletingProject);
                return true;
            }
        }

        public IList<Contract.Entities.Project> GetAllProjectsFromCustomer(Guid customerID)
        {
            return Mapper.Map<IList<Contract.Entities.Project>>(Context.Clients.FirstOrDefault(e => e.Id == customerID).Projects.ToList());
        }

        public Contract.Entities.Project GetProjectByID(Guid id)
        {
            return Mapper.Map<Contract.Entities.Project>(Context.Projects.FirstOrDefault(e => e.Id == id));
        }

        public decimal NumberOfPages(string firstLetter, string filterText, int recordPerPage)
        {
            return Math.Ceiling((decimal)Context.Projects.ToList().Where(project => project.Name[0].ToString().ToLower().Contains(firstLetter) && (project.Name.Contains(filterText) || project.Description.Contains(filterText) || project.Status.Contains(filterText) || project.Client.Name.Contains(filterText) || project.Lead.Name.Contains(filterText))).Count() / recordPerPage);
        }

        public IList<char> ProjectsFirstLetter()
        {
            return Context.Projects.Select(project => project.Name.ToLower()[0]).Distinct().ToList();
        }

        public IList<Contract.Entities.Project> ProjectsOnPage(int page, string firstLetter, string filterText, int recordPerPage)
        {
            return Mapper.Map<IList<Contract.Entities.Project>>(Context.Projects.ToList().Where(project => project.Name[0].ToString().ToLower().Contains(firstLetter) && (project.Name.Contains(filterText) || project.Description.Contains(filterText) || project.Status.Contains(filterText) || project.Client.Name.Contains(filterText) || project.Lead.Name.Contains(filterText))).Skip(page * recordPerPage).Take(recordPerPage).ToList());

        }

        public bool SaveChanges()
        {
            return Context.SaveChanges() > 0;
        }

        public Contract.Entities.Project UpdateProject(Contract.Entities.Project project)
        {
            var updatedProject = Context.Projects.FirstOrDefault(e => e.Id == project.Id);
            if (updatedProject == null)
                throw new ValidationException();
            updatedProject.ClientId = project.ClientId;
            updatedProject.Description = project.Description;
            updatedProject.LeadId = project.LeadId;
            updatedProject.Name = project.Name;
            updatedProject.Status = project.Status;
            return Mapper.Map<Contract.Entities.Project>(updatedProject);
        }
    }
}
