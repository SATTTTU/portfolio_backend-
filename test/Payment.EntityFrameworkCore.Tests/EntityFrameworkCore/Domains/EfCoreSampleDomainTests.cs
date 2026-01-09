using Payment.Samples;
using Xunit;

namespace Payment.EntityFrameworkCore.Domains;

[Collection(PaymentTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<PaymentEntityFrameworkCoreTestModule>
{

}
