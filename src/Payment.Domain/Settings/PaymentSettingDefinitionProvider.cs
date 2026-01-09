using Volo.Abp.Settings;

namespace Payment.Settings;

public class PaymentSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(PaymentSettings.MySetting1));
    }
}
