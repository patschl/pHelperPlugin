namespace Turbo.plugins.patrick.autoactions.actions.town
{
    using System.Collections.Generic;
    using parameters;
    using Plugins;
    using util.diablo;
    using util.thud;

    public class AcceptSalvageDialog : AbstractAutoAction
    {
        public override string tooltip
        {
            get
            {
                return "CAREFUL! Will automatically accept blacksmith's salvage dialog.";
            }
        }

        public override string GetAttributes()
        {
            return "";
        }

        public override List<AbstractParameter> GetParameters()
        {
            return new List<AbstractParameter>();
        }

        public override bool Applicable(IController hud)
        {
            return hud.Game.Me.IsInTown && hud.Render.IsUiElementVisible(UiPathConstants.Blacksmith.SALVAGE_DIALOG);
        }

        public override void Invoke(IController hud)
        {
            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.Blacksmith.SALVAGE_DIALOG_OK, 250);
        }
    }
}