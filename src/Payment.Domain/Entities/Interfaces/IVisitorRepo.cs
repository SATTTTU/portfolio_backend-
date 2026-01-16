using Payment.Entities;
using System;
using Volo.Abp.Domain.Repositories;


namespace Payment.Domain.Repositories
{
    public interface IVisitorRepository : IRepository<Visitor, Guid>
    {
    }
}