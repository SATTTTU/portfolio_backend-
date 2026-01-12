using Payment.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payment.Interfaces
{
    public interface IProjectAppService
    {
        Task<ProjectDto> CreateAsync(CreateProjectDto input);
        Task UpdateAsync(UpdateProjectDto input, Guid id);
        Task<Guid> DeleteAsync(Guid id);
        Task<ProjectDto> GetByIdAsync(Guid id);
        Task<List<ProjectDto>> GetProjectsAsync();
    }
}
