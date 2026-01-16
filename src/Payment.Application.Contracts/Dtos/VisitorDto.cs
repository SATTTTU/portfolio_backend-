using System;


namespace Payment.Application.Contracts
{
    public class VisitorInfoDto
    {
        public int VisitCount { get; set; }
        public DateTime? LastVisitedAt { get; set; }
    }
}