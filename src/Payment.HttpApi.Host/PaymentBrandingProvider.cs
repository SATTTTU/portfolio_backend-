using Microsoft.Extensions.Localization;
using Payment.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Payment;

[Dependency(ReplaceServices = true)]
public class PaymentBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<PaymentResource> _localizer;

    public PaymentBrandingProvider(IStringLocalizer<PaymentResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
