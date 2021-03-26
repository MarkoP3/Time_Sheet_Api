using AutoMapper;
using System;
using System.Collections.Generic;
using timeSheet.Repository.Contract.Data;
using timeSheet.Repository.Contract.Entities;
using timeSheet.Services.Contract.Models.Project;
using timeSheet.Services.Contract.Services;

namespace timeSheet.Services.Services
{
    public class ProjectServices : IProjectServices
    {
        public ProjectServices(IProjectRepository projectRepository)
        {
            ProjectRepository = projectRepository;
            Mapper = TimeSheetMapper.Mapper;
        }

        public IProjectRepository ProjectRepository { get; }
        public IMapper Mapper { get; }

        public ProjectConfirmationDto AddProject(ProjectCreationDto project)
        {
            var addedProject = ProjectRepository.AddProject(Mapper.Map<Project>(project));
            ProjectRepository.SaveChanges();
            return Mapper.Map<ProjectConfirmationDto>(addedProject);
        }

        public IEnumerable<dynamic> AllProjects()
        {
            return ProjectRepository.AllProjects();
        }

        public bool DeleteProject(Guid project)
        {
            var isDeleted = ProjectRepository.DeleteProject(project);
            ProjectRepository.SaveChanges();
            return isDeleted;
        }

        public IEnumerable<ProjectDto> GetAllProjectsFromCustomer(Guid customerID)
        {
            return Mapper.Map<IList<ProjectDto>>(ProjectRepository.GetAllProjectsFromCustomer(customerID));
        }

        public ProjectDto GetProjectByID(Guid id)
        {
            return Mapper.Map<ProjectDto>(ProjectRepository.GetProjectByID(id));
        }

        public decimal NumberOfPages(string firstLetter, string filterText, int? recordPerPage)
        {
            if (firstLetter == null) firstLetter = "";
            if (filterText == null) filterText = "";
            if (recordPerPage == null || recordPerPage <= 0) recordPerPage = 3;
            return ProjectRepository.NumberOfPages(firstLetter, firstLetter, (int)recordPerPage);
        }

        public IEnumerable<char> ProjectsFirstLetter()
        {
            return ProjectRepository.ProjectsFirstLetter();
        }

        public IEnumerable<ProjectDto> ProjectsOnPage(int? page, string firstLetter, string filterText, int? recordPerPage)
        {
            if (firstLetter == null) firstLetter = "";
            if (filterText == null) filterText = "";
            if (recordPerPage == null || recordPerPage <= 0) recordPerPage = 3;
            if (page == null || page <= 0)
            {
                recordPerPage = ProjectRepository.AllProjects().Count;
                page = 0;
            }
            else
            {
                page -= 1;
            }
            return Mapper.Map<IList<ProjectDto>>(ProjectRepository.ProjectsOnPage((int)page, firstLetter, filterText, (int)recordPerPage));
        }

        public ProjectDto UpdateProject(ProjectUpdateDto project, Guid id)
        {

            var projectEntity = Mapper.Map<Project>(project);
            projectEntity.Id = id;
            var updatedProject = ProjectRepository.UpdateProject(projectEntity);
            ProjectRepository.SaveChanges();
            return Mapper.Map<ProjectDto>(updatedProject);
        }
    }
}
