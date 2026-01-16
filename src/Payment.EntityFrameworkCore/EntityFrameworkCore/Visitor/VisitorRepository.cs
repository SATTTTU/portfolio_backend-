using Payment.Domain.Repositories;
using Payment.Entities;
using Payment.EntityFrameworkCore;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

public class VisitorRepository
    : EfCoreRepository<PaymentDbContext, Visitor, Guid>,
      IVisitorRepository
{
    public VisitorRepository(
        IDbContextProvider<PaymentDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }
}
