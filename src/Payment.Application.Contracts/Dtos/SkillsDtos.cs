using System;

namespace Payment.Dtos
{
    public class SkillDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string? ImageUrl { get; set; }
    }

    public class CreateSkillDto
    {
        public string Name { get; set; } = default!;
        public string? ImageUrl { get; set; }
    }

    public class UpdateSkillDto
    {
        public string Name { get; set; } = default!;
        public string? ImageUrl { get; set; }
    }
}
