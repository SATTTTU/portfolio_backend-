using System.Threading.Tasks;

namespace Payment.Data;

public interface IPaymentDbSchemaMigrator
{
    Task MigrateAsync();
}
