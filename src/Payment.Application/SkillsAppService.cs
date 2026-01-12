using Microsoft.Extensions.Logging;
using Payment.Domain.Repositories;
using Payment.Dtos;
using Payment.Extensions;
using Payment.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Payment
{
    public class SkillsAppService : ApplicationService, ISkillsAppService
    {
        private readonly ISkillsRepository _repository;
        private readonly ILogger<SkillsAppService> _logger;

        public SkillsAppService(
            ISkillsRepository repository,
            ILogger<SkillsAppService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<SkillDto> CreateAsync(CreateSkillDto input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            try
            {
                var skill = input.ToEntity();

                await _repository.AddAsync(skill);
                await _repository.SaveChangesAsync();

                return skill.ToDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating skill. Input: {@Input}", input);
                throw new UserFriendlyException("Skill creation failed.", "Please try again later or contact support.");
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
                _logger.LogError(ex, "Error occurred while deleting skill. Id: {Id}", id);
                throw new UserFriendlyException("Delete operation failed.", $"Skill with id '{id}' could not be deleted.");
            }
        }

        public async Task<SkillDto> GetByIdAsync(Guid id)
        {
            var skill = await _repository.GetByIdAsync(id);

            if (skill == null)
            {
                throw new BusinessException("Skill.NotFound").WithData("Id", id);
            }

            return skill.ToDto();
        }

        public async Task UpdateAsync(UpdateSkillDto input, Guid id)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            try
            {
                var skill = await _repository.GetByIdAsync(id);

                if (skill == null)
                {
                    throw new BusinessException("Skill.NotFound").WithData("Id", id);
                }

                skill.UpdateFromDto(input);

                await _repository.UpdateAsync(skill);
                await _repository.SaveChangesAsync();
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating skill. Id: {Id}, Input: {@Input}", id, input);
                throw new UserFriendlyException("Update failed.", "Skill update could not be completed.");
            }
        }

        public async Task<List<SkillDto>> GetSkillsAsync()
        {
            try
            {
                var skills = await _repository.GetAllAsync();
                return skills.ToDtoList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching skills.");
                throw new UserFriendlyException("Failed to load skills.", "Skill list could not be retrieved.");
            }
        }
    }
}
