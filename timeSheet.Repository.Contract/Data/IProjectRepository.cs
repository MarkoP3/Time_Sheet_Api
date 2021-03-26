using System;
using System.Collections.Generic;
using timeSheet.Repository.Contract.Entities;

namespace timeSheet.Repository.Contract.Data
{
    public interface IProjectRepository
    {
        Project AddProject(Project client);
        Project UpdateProject(Project client);
        bool DeleteProject(Guid project);
        IList<Project> ProjectsOnPage(int page, string firstLetter, string filterText, int recordPerPage);
        decimal NumberOfPages(string firstLetter, string filterText, int recordPerPage);
        IList<char> ProjectsFirstLetter();
        IList<Project> AllProjects();
        IList<Project> GetAllProjectsFromCustomer(Guid customerID);
        Project GetProjectByID(Guid id);
        bool SaveChanges();
    }
}
