namespace Turbo.plugins.patrick.autoactions.actions.town
{
    using System.Collections.Generic;
	using System.Text;
    using parameters;
    using Plugins;
    using util.diablo;
    using util.thud;

    public class AutoStartGame : AbstractAutoAction
    {
        public override string tooltip => "Automatically starts game in the lobby.";

        public override string GetAttributes() => "";

        public override long minimumExecutionDelta => 500;

        public override List<AbstractParameter> GetParameters()
        {
            return new List<AbstractParameter>();
        }

        public override bool Applicable(IController hud)
        {
            return !hud.Game.IsInGame 
            && !hud.Game.IsLoading
            && hud.Render.IsUiElementVisible(UiPathConstants.Buttons.START_GAME)
            && hud.Render.GetUiElement(UiPathConstants.Buttons.START_GAME)
                  .ReadText(Encoding.ASCII, true).Contains("Start");
        }

        public override void Invoke(IController hud)
        {
            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.Buttons.START_GAME);
        }
    }
}