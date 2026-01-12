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
    public class WorkAppService : ApplicationService, IWorkAppService
    {
        private readonly IWorkRepository _repository;
        private readonly ILogger<WorkAppService> _logger;

        public WorkAppService(
            IWorkRepository repository,
            ILogger<WorkAppService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<WorkResponse> CreateAsync(CreateWorkDto input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            try
            {
                var overview = input.ToEntity();

                await _repository.AddAsync(overview);
                await _repository.SaveChangesAsync();

                return overview.ToResponse();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating overview. Input: {@Input}", input);
                throw new UserFriendlyException("Overview creation failed.", "Please try again later or contact support.");
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
                _logger.LogError(ex, "Error occurred while deleting overview. Id: {Id}", id);
                throw new UserFriendlyException("Delete operation failed.", $"Overview with id '{id}' could not be deleted.");
            }
        }

        public async Task<WorkResponse> GetByIdAsync(Guid id)
        {
            var overview = await _repository.GetByIdAsync(id);

            if (overview == null)
            {
                throw new BusinessException("Overview.NotFound").WithData("Id", id);
            }

            return overview.ToResponse();
        }

        public async Task UpdateAsync(UpdateWorkDto input, Guid id)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            try
            {
                var overview = await _repository.GetByIdAsync(id);

                if (overview == null)
                {
                    throw new BusinessException("Overview.NotFound").WithData("Id", id);
                }

                overview.UpdateFromDto(input);

                await _repository.UpdateAsync(overview);
                await _repository.SaveChangesAsync();
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating overview. Id: {Id}, Input: {@Input}", id, input);
                throw new UserFriendlyException("Update failed.", "Overview update could not be completed.");
            }
        }

        public async Task<List<WorkResponse>> GetWorksAsync()
        {
            try
            {
                var overviews = await _repository.GetAllAsync();
                return overviews.ToResponseList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching overviews.");
                throw new UserFriendlyException("Failed to load overviews.", "Overview list could not be retrieved.");
            }
        }
    }
}

