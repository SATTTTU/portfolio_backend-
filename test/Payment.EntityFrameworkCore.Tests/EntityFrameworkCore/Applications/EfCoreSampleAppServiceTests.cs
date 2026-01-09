using Payment.Samples;
using Xunit;

namespace Payment.EntityFrameworkCore.Applications;

[Collection(PaymentTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<PaymentEntityFrameworkCoreTestModule>
{

}
