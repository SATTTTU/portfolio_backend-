using Xunit;

namespace Payment.EntityFrameworkCore;

[CollectionDefinition(PaymentTestConsts.CollectionDefinitionName)]
public class PaymentEntityFrameworkCoreCollection : ICollectionFixture<PaymentEntityFrameworkCoreFixture>
{

}
