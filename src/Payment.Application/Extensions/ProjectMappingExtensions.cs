using Payment.Dtos;
using Payment.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Payment.Extensions
{
    public static class ProjectMappingExtensions
    {
        public static ProjectDto ToDto(this Entities.Projects project)
        {
            if (project == null) return null!;

            return new ProjectDto
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                ImageUrl = project.ImageUrl,
                ProjectUrl = project.ProjectUrl,
                GithubUrl = project.GithubUrl
            };
        }

        public static List<ProjectDto> ToDtoList(this IEnumerable<Entities.Projects> projects)
        {
            return projects.Select(p => p.ToDto()).ToList();
        }

        public static Entities.Projects ToEntity(this CreateProjectDto dto)
        {
            return new Entities.Projects(dto.Title, dto.Description, dto.ImageUrl, dto.ProjectUrl, dto.GithubUrl);
        }

        public static void UpdateFromDto(this Entities.Projects entity, UpdateProjectDto dto)
        {
            entity.Update(dto.Title, dto.Description, dto.ImageUrl, dto.ProjectUrl, dto.GithubUrl);
        }
    }
}
