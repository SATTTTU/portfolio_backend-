using Microsoft.Extensions.Logging;
using Payment;
using Payment.Domain.Repositories;
using Payment.Dtos;
using Payment.Entities;
using Payment.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace OverviewService
{
    public class PaymentAppService : ApplicationService, IOverviewAppService
    {
        private readonly IOverviewRepository _repository;
        private readonly ILogger<PaymentAppService> _logger;
        private readonly PaymentApplicationMappers _mapper;

        public PaymentAppService(
            IOverviewRepository repository,
            ILogger<PaymentAppService> logger,
            PaymentApplicationMappers mappers)  
        {
            _repository = repository;
            _logger = logger;
            _mapper = mappers;
        }

        public async Task<OverviewResponse> CreateAsync(CreateOverviewDto input)
        {
            try
            {
                if (input is null)
                {
                    throw new ArgumentNullException(nameof(input));
                }

                var overview = _mapper.Map(input);

                await _repository.AddAsync(overview);
                await _repository.SaveChangesAsync();

                return _mapper.Map(overview);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error occurred while creating overview. Input: {@Input}",
                    input
                );

                throw new UserFriendlyException(
                    "Overview creation failed.",
                    "Please try again later or contact support."
                );
            }
        }


        public async Task<Guid> DeleteAsync(Guid id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error occurred while deleting overview. Id: {Id}",
                    id
                );

                throw new UserFriendlyException(
                    "Delete operation failed.",
                    $"Overview with id '{id}' could not be deleted."
                );
            }
        }

        public async Task<OverviewResponse> GetByIdAsync(Guid id)
        {
            try
            {
                var overview = await _repository.GetByIdAsync(id);

                if (overview == null)
                {
                    throw new BusinessException("Overview.NotFound")
                        .WithData("Id", id);
                }

                return ObjectMapper.Map<Overviews, OverviewResponse>(overview);
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error occurred while fetching overview. Id: {Id}",
                    id
                );

                throw new UserFriendlyException(
                    "Failed to retrieve overview.",
                    "The requested overview could not be fetched."
                );
            }
        }

        public async Task UpdateAsync( UpdateOverviewDto input,Guid id)
        {
            try
            {
                var overview = await _repository.GetByIdAsync(id);

                if (overview == null)
                {
                    throw new BusinessException("Overview.NotFound")
                        .WithData("Id", id);
                }

                ObjectMapper.Map(input, overview);

                await _repository.UpdateAsync(overview);
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error occurred while updating overview. Id: {Id}, Input: {@Input}",
                    id,
                    input
                );

                throw new UserFriendlyException(
                    "Update failed.",
                    "Overview update could not be completed."
                );
            }
        }

        public async Task<ListResultDto<OverviewResponse>> GetOverviewsAsync(OverviewResponse response)
        {
            try
            {
                var overviews = await _repository.GetAllAsync();

                return new ListResultDto<OverviewResponse>(
                    ObjectMapper.Map<List<Overviews>, List<OverviewResponse>>((List<Overviews>)overviews)
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching overviews.");

                throw new UserFriendlyException(
                    "Failed to load overviews.",
                    "Overview list could not be retrieved."
                );
            }
        }
    }
}
