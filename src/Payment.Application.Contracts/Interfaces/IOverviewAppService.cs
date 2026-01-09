using Payment.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Payment.Interfaces
{
    public  interface IOverviewAppService
    {
        public Task<OverviewResponse> CreateAsync(CreateOverviewDto input);
        public Task UpdateAsync(UpdateOverviewDto input, Guid id);
        public Task<Guid> DeleteAsync(Guid id);
        public Task<OverviewResponse> GetByIdAsync(Guid id);
        public Task<ListResultDto<OverviewResponse>> GetOverviewsAsync(OverviewResponse response);
    }
}
