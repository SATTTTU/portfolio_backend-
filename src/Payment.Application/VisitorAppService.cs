using Microsoft.AspNetCore.Http;
using Payment.Application.Contracts;
using Payment.Domain.Repositories;
using Payment.Entities;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Payment.Application
{
    public class VisitorAppService : ApplicationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IVisitorRepository _visitorRepository;

        public VisitorAppService(
            IHttpContextAccessor httpContextAccessor,
            IVisitorRepository visitorRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _visitorRepository = visitorRepository;
        }

        public async Task<VisitorInfoDto> TrackAsync()
        {
            var context = _httpContextAccessor.HttpContext!;
            var request = context.Request;
            var response = context.Response;

            if (!request.Cookies.TryGetValue("visitor_id", out var identity))
            {
                identity = Guid.NewGuid().ToString();
                response.Cookies.Append("visitor_id", identity, new CookieOptions
                {
                    HttpOnly = true,
                    IsEssential = true
                });
            }

            var visitor = await _visitorRepository
                .FirstOrDefaultAsync(v => v.Identity == identity);

            DateTime? lastVisit = null;

            if (visitor == null)
            {
                visitor = new Visitor(identity);
                await _visitorRepository.InsertAsync(visitor, autoSave: true);
            }
            else
            {
                lastVisit = visitor.LastVisitedAt;
                visitor.Touch();
                await _visitorRepository.UpdateAsync(visitor, autoSave: true);
            }

            return new VisitorInfoDto
            {
                VisitCount = visitor.VisitCount,
                LastVisitedAt = lastVisit
            };
        }
    }
}
