using System;

namespace Payment.Entities
{
    public class WorkingDescription
    {
        public Guid Id { get; private set; }
        public Guid WorkingId { get; private set; }
        public string Value { get; private set; } = default!;

        protected WorkingDescription() { }

        public WorkingDescription(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Description cannot be empty.");

            Id = Guid.NewGuid();
            Value = value;
        }
    }
}
