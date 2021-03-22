using System;
using System.Collections.Generic;
using timeSheetApi.Entities;

namespace timeSheetApi.Data
{
    public interface IProjectRepository
    {
        Project AddProject(Project client);
        Project UpdateProject(Project client);
        bool DeleteProject(Guid client);
        IList<Project> ProjectsOnPage(int page, string firstLetter, string filterText, int recordPerPage);
        decimal NumberOfPages(string firstLetter, string filterText, int recordPerPage);
        IList<char> ProjectsFirstLetter();
        IList<dynamic> AllProjects();
        IList<Project> GetAllProjectsFromCustomer(Guid customerID);
        Project GetProjectByID(Guid id);
    }
}
