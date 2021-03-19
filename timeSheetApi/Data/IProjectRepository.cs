using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using timeSheetApi.Models;

namespace timeSheetApi.Data
{
    public interface IProjectRepository
    {
        ProjectDto AddProject(ProjectDto client);
        ProjectDto UpdateProject(ProjectDto client);
        bool DeleteProject(Guid client);
        IList<ProjectDto> ProjectsOnPage(int page, string firstLetter, string filterText, int recordPerPage);
        decimal NumberOfPages(string firstLetter, string filterText, int recordPerPage);
        IList<char> ProjectsFirstLetter();
        IList<dynamic> AllProjects ();
    }
}
