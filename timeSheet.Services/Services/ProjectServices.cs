using AutoMapper;
using System;
using System.Collections.Generic;
using timeSheet.Common.Entities;
using timeSheet.Common.Models.Project;
using timeSheet.Services.Data;

namespace timeSheet.Services.Services
{
    public class ProjectServices : IProjectServices
    {
        public ProjectServices(IProjectRepository projectRepository, IMapper mapper)
        {
            ProjectRepository = projectRepository;
            Mapper = mapper;
        }

        public IProjectRepository ProjectRepository { get; }
        public IMapper Mapper { get; }

        public ProjectDto AddProject(ProjectCreationDto project)
        {
            return Mapper.Map<ProjectDto>(ProjectRepository.AddProject(Mapper.Map<Project>(project)));
        }

        public IList<dynamic> AllProjects()
        {
            return ProjectRepository.AllProjects();
        }

        public bool DeleteProject(Guid project)
        {
            return ProjectRepository.DeleteProject(project);
        }

        public IList<ProjectDto> GetAllProjectsFromCustomer(Guid customerID)
        {
            return Mapper.Map<IList<ProjectDto>>(ProjectRepository.GetAllProjectsFromCustomer(customerID));
        }

        public ProjectDto GetProjectByID(Guid id)
        {
            return Mapper.Map<ProjectDto>(ProjectRepository.GetProjectByID(id));
        }

        public decimal NumberOfPages(string firstLetter, string filterText, int recordPerPage)
        {
            return ProjectRepository.NumberOfPages(firstLetter, firstLetter, recordPerPage);
        }

        public IList<char> ProjectsFirstLetter()
        {
            return ProjectRepository.ProjectsFirstLetter();
        }

        public IList<ProjectDto> ProjectsOnPage(int page, string firstLetter, string filterText, int recordPerPage)
        {
            return Mapper.Map<IList<ProjectDto>>(ProjectRepository.ProjectsOnPage(page, firstLetter, filterText, recordPerPage));
        }

        public ProjectDto UpdateProject(ProjectUpdateDto project)
        {
            return Mapper.Map<ProjectDto>(ProjectRepository.UpdateProject(Mapper.Map<Project>(project)));
        }
    }
}
