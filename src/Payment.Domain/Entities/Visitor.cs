using System;
using Volo.Abp.Domain.Entities;


namespace Payment.Entities
{
    public class Visitor : AggregateRoot<Guid>
    {
        public string Identity { get; private set; } = default!;
        public DateTime FirstVisitedAt { get; private set; }
        public DateTime LastVisitedAt { get; private set; }
        public int VisitCount { get; private set; }


        protected Visitor() { }


        public Visitor(string identity)
        {
            Id = Guid.NewGuid();
            Identity = identity;
            FirstVisitedAt = DateTime.UtcNow;
            LastVisitedAt = FirstVisitedAt;
            VisitCount = 1;
        }


        public void Touch()
        {
            LastVisitedAt = DateTime.UtcNow;
            VisitCount++;
        }
    }
}