using Payment.Dtos;
using Payment.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Payment.Extensions
{
    public static class SkillsMappingExtension
    {
        public static SkillDto ToDto(this Entities.Skills skill)
        {
            if (skill == null) return null!;

            return new SkillDto
            {
                Id = skill.Id,
                Name = skill.Name,
                ImageUrl = skill.ImageUrl
            };
        }

        public static List<SkillDto> ToDtoList(this IEnumerable<Entities.Skills> skills)
        {
            return skills.Select(s => s.ToDto()).ToList();
        }

        public static Entities.Skills ToEntity(this CreateSkillDto dto)
        {
            return new Entities.Skills(dto.Name, dto.ImageUrl);
        }

        public static void UpdateFromDto(this Entities.Skills entity, UpdateSkillDto dto)
        {
            entity.Update(dto.Name, dto.ImageUrl);
        }
    }
}
