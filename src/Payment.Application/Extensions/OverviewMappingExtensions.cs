using Payment.Dtos;
using Payment.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Payment.Extensions
{
    public static class OverviewMappingExtensions
    {
        public static OverviewResponse ToResponse(this Overview overview)
        {
            if (overview == null) return null!;

            return new OverviewResponse
            {
                Id = overview.Id,
                Title = overview.Title,
                ImageUrl = overview.ImageUrl
            };
        }

        public static List<OverviewResponse> ToResponseList(this IEnumerable<Overview> overviews)
        {
            return overviews.Select(o => o.ToResponse()).ToList();
        }

        public static Overview ToEntity(this CreateOverviewDto dto)
        {
            return new Overview(dto.Title, dto.ImageUrl);
        }

        public static void UpdateFromDto(this Overview entity, UpdateOverviewDto dto)
        {
            entity.Update(dto.Title, dto.ImageUrl);
        }
    }
}
