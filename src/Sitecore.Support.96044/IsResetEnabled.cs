using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.ExperienceEditor.Speak.Ribbon.Requests.ResetLayout;
using Sitecore.ExperienceEditor.Speak.Server.Responses;
using System;

namespace Sitecore.Support.ExperienceEditor.Speak.Ribbon.Requests.ResetLayout
{
    public class IsResetEnabled : IsEnabled
    {
        public override bool GetCommandState()
        {
            Item item = base.RequestContext.Item;
            return !(!TemplateManager.IsFieldPartOfTemplate(FieldIDs.Workflow, item) | !TemplateManager.IsFieldPartOfTemplate(FieldIDs.WorkflowState, item)) && item.Access.CanWrite() && item.Access.CanWriteLanguage() && (Context.IsAdministrator || !item.Locking.IsLocked() || item.Locking.HasLock()) && !item.Appearance.ReadOnly && base.GetCommandState();
        }

        public override PipelineProcessorResponseValue ProcessRequest()
        {
            base.RequestContext.ValidateContextItem();
            PipelineProcessorResponseValue pipelineProcessorResponseValue = new PipelineProcessorResponseValue();
            pipelineProcessorResponseValue.Value = this.GetCommandState();
            return pipelineProcessorResponseValue;
        }
    }
}
