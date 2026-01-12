using System;

namespace Payment.Entities
{
    public class Skills
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = default!;
        public string? ImageUrl { get; private set; }

        protected Skills() { } // EF Core only

        public Skills(string name, string? imageUrl)
        {
            Id = Guid.NewGuid();
            SetName(name);
            SetImageUrl(imageUrl);
        }

        public void Update(string name, string? imageUrl)
        {
            SetName(name);
            SetImageUrl(imageUrl);
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }

            Name = name;
        }

        private void SetImageUrl(string? imageUrl)
        {
            ImageUrl = imageUrl;
        }
    }
}
