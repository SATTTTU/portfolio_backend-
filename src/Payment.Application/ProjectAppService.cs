using Microsoft.Extensions.Logging;
using Payment.Domain.Repositories;
using Payment.Dtos;
using Payment.Entities;
using Payment.Extensions;
using Payment.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Payment
{
    public class ProjectAppService : ApplicationService, IProjectAppService
    {
        private readonly IProjectRepository _repository;
        private readonly ILogger<ProjectAppService> _logger;

        public ProjectAppService(
            IProjectRepository repository,
            ILogger<ProjectAppService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ProjectDto> CreateAsync(CreateProjectDto input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            try
            {
                var project = input.ToEntity();

                await _repository.AddAsync(project);
                await _repository.SaveChangesAsync();

                return project.ToDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating project. Input: {@Input}", input);
                throw new UserFriendlyException("Project creation failed.", "Please try again later or contact support.");
            }
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                await _repository.SaveChangesAsync();
                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting project. Id: {Id}", id);
                throw new UserFriendlyException("Delete operation failed.", $"Project with id '{id}' could not be deleted.");
            }
        }

        public async Task<ProjectDto> GetByIdAsync(Guid id)
        {
            var project = await _repository.GetByIdAsync(id);

            if (project == null)
            {
                throw new BusinessException("Project.NotFound").WithData("Id", id);
            }

            return project.ToDto();
        }

        public async Task UpdateAsync(UpdateProjectDto input, Guid id)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            try
            {
                var project = await _repository.GetByIdAsync(id);

                if (project == null)
                {
                    throw new BusinessException("Project.NotFound").WithData("Id", id);
                }

                project.UpdateFromDto(input);

                await _repository.UpdateAsync(project);
                await _repository.SaveChangesAsync();
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating project. Id: {Id}, Input: {@Input}", id, input);
                throw new UserFriendlyException("Update failed.", "Project update could not be completed.");
            }
        }

        public async Task<List<ProjectDto>> GetProjectsAsync()
        {
            try
            {
                var projects = await _repository.GetAllAsync();
                return projects.ToDtoList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching projects.");
                throw new UserFriendlyException("Failed to load projects.", "Project list could not be retrieved.");
            }
        }
    }
}
