namespace Turbo.plugins.patrick.autoactions.actions.town
{
    using System.Collections.Generic;
	using System.Text;
    using parameters;
    using Plugins;
    using util.diablo;
    using util.thud;

    public class AutoDialog : AbstractAutoAction
    {
        public override string tooltip => "Automatically skip dialogs.";

        public override long minimumExecutionDelta => 100;

        public override string GetAttributes() => "";

        public override List<AbstractParameter> GetParameters()
        {
            return new List<AbstractParameter>();
        }

        public override bool Applicable(IController hud)
        {
            return hud.Render.IsUiElementVisible(UiPathConstants.Dialogs.CONVERSATION_CLOSE_BUTTON);
        }

        public override void Invoke(IController hud)
        {
            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.Dialogs.CONVERSATION_CLOSE_BUTTON);
        }
    }
}