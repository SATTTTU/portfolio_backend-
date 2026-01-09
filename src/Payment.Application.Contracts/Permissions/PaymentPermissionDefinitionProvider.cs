using Payment.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Payment.Permissions;

public class PaymentPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(PaymentPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(PaymentPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<PaymentResource>(name);
    }
}
