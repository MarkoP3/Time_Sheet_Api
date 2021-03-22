using System;
using System.Collections.Generic;
using timeSheetApi.Models.Project;

namespace timeSheetApi.Services
{
    public interface IProjectServices
    {
        ProjectDto AddProject(ProjectCreationDto client);
        ProjectDto UpdateProject(ProjectUpdateDto client);
        bool DeleteProject(Guid client);
        IList<ProjectDto> ProjectsOnPage(int page, string firstLetter, string filterText, int recordPerPage);
        decimal NumberOfPages(string firstLetter, string filterText, int recordPerPage);
        IList<char> ProjectsFirstLetter();
        IList<dynamic> AllProjects();
        IList<ProjectDto> GetAllProjectsFromCustomer(Guid customerID);
        ProjectDto GetProjectByID(Guid id);
    }
}
