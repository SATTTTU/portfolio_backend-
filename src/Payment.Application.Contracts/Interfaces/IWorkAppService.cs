using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payment.Interfaces
{
    public interface IWorkAppService
    {
        public Task<WorkResponse> CreateAsync(CreateWorkDto input);
        public Task UpdateAsync(UpdateWorkDto input, Guid id);
        public Task<Guid> DeleteAsync(Guid id);
        public Task<WorkResponse> GetByIdAsync(Guid id);
        public Task<List<WorkResponse>> GetWorksAsync();
    }
}
