using System;
using System.Collections.Generic;
using timeSheet.Services.Contract.Models.Project;

namespace timeSheet.Services.Contract.Services
{
    public interface IProjectServices
    {
        ProjectConfirmationDto AddProject(ProjectCreationDto client);
        ProjectDto UpdateProject(ProjectUpdateDto client, Guid project);
        bool DeleteProject(Guid client);
        IEnumerable<ProjectDto> ProjectsOnPage(int? page, string firstLetter, string filterText, int? recordPerPage);
        decimal NumberOfPages(string firstLetter, string filterText, int? recordPerPage);
        IEnumerable<char> ProjectsFirstLetter();
        IEnumerable<dynamic> AllProjects();
        IEnumerable<ProjectDto> GetAllProjectsFromCustomer(Guid customerID);
        ProjectDto GetProjectByID(Guid id);
    }
}
