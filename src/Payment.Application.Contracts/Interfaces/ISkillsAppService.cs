using Payment.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payment.Interfaces
{
    public interface ISkillsAppService
    {
        Task<SkillDto> CreateAsync(CreateSkillDto input);
        Task UpdateAsync(UpdateSkillDto input, Guid id);
        Task<Guid> DeleteAsync(Guid id);
        Task<SkillDto> GetByIdAsync(Guid id);
        Task<List<SkillDto>> GetSkillsAsync();
    }
}
