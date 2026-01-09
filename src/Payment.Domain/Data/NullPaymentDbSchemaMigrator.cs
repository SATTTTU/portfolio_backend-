using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Payment.Data;

/* This is used if database provider does't define
 * IPaymentDbSchemaMigrator implementation.
 */
public class NullPaymentDbSchemaMigrator : IPaymentDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
