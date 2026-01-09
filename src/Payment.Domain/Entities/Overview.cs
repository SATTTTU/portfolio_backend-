using System;

namespace Payment.Entities
{
    public class Overviews
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; } = default!;
        public string? ImageUrl { get; private set; }

        protected Overviews() { } // EF Core only

        public Overviews(string title, string? imageUrl)
        {
            Id = Guid.NewGuid();
            SetTitle(title);
            SetImageUrl(imageUrl);
        }

        private void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be null or empty.", nameof(title));
            }

            Title = title;
        }

        private void SetImageUrl(string? imageUrl)
        {
            ImageUrl = imageUrl; // null allowed
        }
    }
}
