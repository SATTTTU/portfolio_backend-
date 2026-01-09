using Payment.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Payment.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class PaymentController : AbpControllerBase
{
    protected PaymentController()
    {
        LocalizationResource = typeof(PaymentResource);
    }
}
