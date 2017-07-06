using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.ExperienceEditor.Speak.Ribbon.Requests.LayoutDetails;
using System;

namespace Sitecore.Support.ExperienceEditor.Speak.Ribbon.Requests.LayoutDetails
{
    public class CustomCanEditLayoutDetailsRequest : CanEditLayoutDetailsRequest
    {
        public override bool GetCommandState()
        {
            Item item = base.RequestContext.Item;
            return !(!TemplateManager.IsFieldPartOfTemplate(FieldIDs.Workflow, item) | !TemplateManager.IsFieldPartOfTemplate(FieldIDs.WorkflowState, item)) && item.Access.CanWrite() && item.Access.CanWriteLanguage() && (Context.IsAdministrator || !item.Locking.IsLocked() || item.Locking.HasLock()) && !item.Appearance.ReadOnly && base.GetCommandState();
        }
    }
}
