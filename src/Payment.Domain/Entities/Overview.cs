using System;

namespace Payment.Entities
{
    public class Overview
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; } = default!;
        public string? ImageUrl { get; private set; }

        protected Overview() { } // EF Core only

        public Overview(string title, string? imageUrl)
        {
            Id = Guid.NewGuid();
            SetTitle(title);
            SetImageUrl(imageUrl);
        }

        public void Update(string title, string? imageUrl)
        {
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

