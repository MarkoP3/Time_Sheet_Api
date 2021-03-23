﻿using System;
using System.Collections.Generic;
using timeSheet.Common.Entities;

namespace timeSheet.Services.Data
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
