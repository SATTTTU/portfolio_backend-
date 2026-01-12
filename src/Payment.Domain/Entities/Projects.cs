using System;

namespace Payment.Entities
{
    public class Projects
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public string? ImageUrl { get; private set; }
        public string? ProjectUrl { get; private set; }
        public string? GithubUrl { get; private set; }

        protected Projects() { } // EF Core only

        public Projects(string title, string description, string? imageUrl, string? projectUrl, string? githubUrl)
        {
            Id = Guid.NewGuid();
            SetState(title, description, imageUrl, projectUrl, githubUrl);
        }

        public void Update(string title, string description, string? imageUrl, string? projectUrl, string? githubUrl)
        {
            SetState(title, description, imageUrl, projectUrl, githubUrl);
        }

        private void SetState(string title, string description, string? imageUrl, string? projectUrl, string? githubUrl)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be null or empty.", nameof(title));

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be null or empty.", nameof(description));

            Title = title;
            Description = description;
            ImageUrl = imageUrl;
            ProjectUrl = projectUrl;
            GithubUrl = githubUrl;
        }
    }
}
