using Sitecore.Configuration;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Shell.Framework.Commands.Masters;
using ResetOrigin = Sitecore.Shell.Applications.Layouts.PageDesigner.Commands.Reset;

namespace Sitecore.Support.Shell.Applications.Layouts.PageDesigner.Commands
{
    public class CustomReset : ResetOrigin
	{
        public override CommandState QueryState(CommandContext context)
        {
            Assert.ArgumentNotNull(context, "context");
            CommandState result;
            if (context.Items.Length == 1)
            {
                Item item = context.Items[0];
                if (!Context.IsAdministrator && Settings.RequireLockBeforeEditing && base.HasField(item, FieldIDs.Lock) && !item.Locking.HasLock() && !(item.TemplateID == TemplateIDs.Template))
                {
                    result = CommandState.Disabled;
                    return result;
                }
            }
            result = base.QueryState(context);
            return result;
        }
    }
}
