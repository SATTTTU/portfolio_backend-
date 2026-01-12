using System;

namespace Payment.Dtos
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string? ImageUrl { get; set; }
        public string? ProjectUrl { get; set; }
        public string? GithubUrl { get; set; }
    }

    public class CreateProjectDto
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string? ImageUrl { get; set; }
        public string? ProjectUrl { get; set; }
        public string? GithubUrl { get; set; }
    }

    public class UpdateProjectDto
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string? ImageUrl { get; set; }
        public string? ProjectUrl { get; set; }
        public string? GithubUrl { get; set; }
    }
}
