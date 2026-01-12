using System;
using System.Collections.Generic;
using System.Linq;

namespace Payment.Entities
{
    public class Working
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; } = default!;

        public IReadOnlyCollection<WorkingDescription> Descriptions => _descriptions;
        private List<WorkingDescription> _descriptions = new();

        public DateTime StartedAt { get; private set; }
        public DateTime? LeftAt { get; private set; }
        public bool IsWorking { get; private set; }
        public string WorkedAt { get; private set; } = default!;

        protected Working() { }

        public Working(
            string title,
            IEnumerable<string> descriptions,
            DateTime startedAt,
            DateTime? leftAt,
            bool isWorking,
            string workedAt)
        {
            Id = Guid.NewGuid();
            ApplyState(title, descriptions, startedAt, leftAt, isWorking, workedAt);
        }

        public void Update(
            string title,
            IEnumerable<string> descriptions,
            DateTime startedAt,
            DateTime? leftAt,
            bool isWorking,
            string workedAt)
        {
            ApplyState(title, descriptions, startedAt, leftAt, isWorking, workedAt);
        }

        private void ApplyState(
            string title,
            IEnumerable<string> descriptions,
            DateTime startedAt,
            DateTime? leftAt,
            bool isWorking,
            string workedAt)
        {
            SetTitle(title);
            UpdateDescriptions(descriptions);
            SetStartedAt(startedAt);
            SetLeftAt(startedAt, leftAt, isWorking);
            SetIsWorking(isWorking, leftAt);
            SetWorkedAt(workedAt);
        }

        private void UpdateDescriptions(IEnumerable<string> descriptions)
        {
            if (descriptions == null || !descriptions.Any())
                throw new ArgumentException("At least one description is required.", nameof(descriptions));

            _descriptions.Clear();

            foreach (var desc in descriptions)
            {
                _descriptions.Add(new WorkingDescription(desc));
            }
        }

        private void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be null or empty.");

            if (title.Length > 100)
                throw new ArgumentException("Title cannot exceed 100 characters.");

            Title = title;
        }

        private void SetStartedAt(DateTime startedAt)
        {
            if (startedAt > DateTime.UtcNow)
                throw new ArgumentException("StartedAt cannot be in the future.");

            StartedAt = startedAt;
        }

        private void SetLeftAt(DateTime startedAt, DateTime? leftAt, bool isWorking)
        {
            if (isWorking && leftAt.HasValue)
                throw new ArgumentException("LeftAt must be null when IsWorking is true.");

            if (!isWorking && !leftAt.HasValue)
                throw new ArgumentException("LeftAt is required when IsWorking is false.");

            if (leftAt.HasValue && leftAt < startedAt)
                throw new ArgumentException("LeftAt cannot be earlier than StartedAt.");

            LeftAt = leftAt;
        }

        private void SetIsWorking(bool isWorking, DateTime? leftAt)
        {
            IsWorking = isWorking;
        }

        private void SetWorkedAt(string workedAt)
        {
            if (string.IsNullOrWhiteSpace(workedAt))
                throw new ArgumentException("WorkedAt cannot be null or empty.");

            if (workedAt.Length > 200)
                throw new ArgumentException("WorkedAt cannot exceed 200 characters.");

            WorkedAt = workedAt;
        }
    }
}
