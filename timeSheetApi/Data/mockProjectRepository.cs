using System;
using System.Collections.Generic;
using System.Linq;
using timeSheetApi.Entities;

namespace timeSheetApi.Data
{
    public class mockProjectRepository : IProjectRepository
    {
        IList<Project> projects = new List<Project>();
        public mockProjectRepository()
        {
            projects.Add(new Project() { Lead = "Predrag Predragovic", Client = "Vega", ClientId = Guid.Parse("4e02ba79-776b-4c2a-b1e0-7d2e71e641c7"), Id = Guid.Parse("7d895dcd-bd06-4a5f-b740-ce88a8991ae2"), LeadId = Guid.Parse("42b667ab-d17b-4a8f-aa97-a3f5c62467c1"), Description = "Ovo je neki opis", Name = "Projekat 1", Status = "Archive" });
        }
        public Project AddProject(Project project)
        {
            project.Id = Guid.NewGuid();
            projects.Add(project);
            return projects.First(el => el.Id == project.Id);
        }

        public IList<dynamic> AllProjects()
        {
            List<dynamic> list = new List<dynamic>();
            foreach (var project in projects)
                list.Add(new { project.Id, project.Name });
            return list;
        }

        public bool DeleteProject(Guid project)
        {
            projects = projects.Where((el) => el.Id != project).ToList();
            return true;
        }

        public IList<Project> GetAllProjectsFromCustomer(Guid customerID)
        {
            return projects.Where(e => e.ClientId == customerID).ToList();
        }

        public Project GetProjectByID(Guid id)
        {
            return projects.Where(e => e.Id == id).First();
        }

        public decimal NumberOfPages(string firstLetter, string filterText, int recordPerPage)
        {
            return Math.Ceiling((decimal)projects.Where(project => project.Name[0].ToString().ToLower().Contains(firstLetter) && (project.Name.Contains(filterText) || project.Description.Contains(filterText) || project.Status.Contains(filterText) || project.Client.Contains(filterText) || project.Lead.Contains(filterText))).Count() / recordPerPage);
        }

        public IList<char> ProjectsFirstLetter()
        {
            return projects.Select(project => project.Name.ToLower()[0]).Distinct().ToList();
        }

        public IList<Project> ProjectsOnPage(int page, string firstLetter, string filterText, int recordPerPage)
        {
            return projects.Where(project => project.Name[0].ToString().ToLower().Contains(firstLetter) && (project.Name.Contains(filterText) || project.Description.Contains(filterText) || project.Status.Contains(filterText) || project.Client.Contains(filterText) || project.Lead.Contains(filterText))).Skip(page * recordPerPage).Take(recordPerPage).ToList();

        }

        public Project UpdateProject(Project project)
        {
            var current = projects.Where(el => el.Id == project.Id).FirstOrDefault();
            var index = projects.IndexOf(current);
            projects[index] = project;
            return projects[index];
        }
    }
}
