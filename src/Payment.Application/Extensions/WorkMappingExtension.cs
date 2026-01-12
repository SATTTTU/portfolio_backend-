using Payment.Dtos;
using Payment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Payment.Extensions
{
    public static class WorkMappingExtensions
    {
        public static WorkResponse ToResponse(this Working working)
        {
            if (working is null) return null!;

            return new WorkResponse
            {
                Id = working.Id,
                Title = working.Title,
                Descriptions = working.Descriptions.Select(d => d.Value).ToList(),
                StartedAt = working.StartedAt,
                LeftAt = working.LeftAt,
                IsWorking = working.IsWorking,
                WorkedAt = working.WorkedAt
            };
            
        }

        public static List<WorkResponse> ToResponseList(this IEnumerable<Working> workings)
        {
            return workings.Select(o => o.ToResponse()).ToList();
        }

        public static Working ToEntity(this CreateWorkDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));

            return new Working(
                dto.Title,
                dto.Descriptions,
                dto.StartedAt,
                dto.LeftAt,
                dto.IsWorking,
                dto.WorkedAt
            );
        }


      

           public static void UpdateFromDto(this Working entity, UpdateWorkDto dto)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            entity.Update(
                dto.Title,
                dto.Descriptions,
                dto.StartedAt,
                dto.LeftAt,
                dto.IsWorking,
                dto.WorkedAt
            );
        }

    }

}

