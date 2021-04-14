namespace Turbo.plugins.patrick.autoactions.actions.town
{
    using System.Collections.Generic;
    using parameters;
    using Plugins;
    using util.diablo;
    using util.thud;

    public class AcceptSalvageDialog : AbstractAutoAction
    {
        public override string tooltip => "CAREFUL! Will automatically accept blacksmith's salvage dialog.";

        public override string GetAttributes() => "";

        public override long minimumExecutionDelta => 72;

        public override List<AbstractParameter> GetParameters()
        {
            return new List<AbstractParameter>();
        }

        public override bool Applicable(IController hud)
        {
            if (!hud.Game.Me.IsInTown || !hud.Render.IsUiElementVisible(UiPathConstants.Blacksmith.SALVAGE_DIALOG))
                return false;

            var anvil = hud.Render.GetOrRegisterAndGetUiElement(UiPathConstants.Blacksmith.ANVIL);
            if (anvil == null || !anvil.Visible)
                return false;

            return anvil.AnimState > 10;
        }

        public override void Invoke(IController hud)
        {
            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.Blacksmith.SALVAGE_DIALOG_OK, 250);
        }
    }
}