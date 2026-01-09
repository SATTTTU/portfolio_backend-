using Volo.Abp.Modularity;

namespace Payment;

public abstract class PaymentApplicationTestBase<TStartupModule> : PaymentTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
