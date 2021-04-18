namespace Turbo.plugins.patrick.autoactions.actions.town
{
    using System.Collections.Generic;
    using parameters;
    using Plugins;
    using util.diablo;
    using util.thud;

    public class AutoStartGame : AbstractAutoAction
    {
        public override string tooltip => "Automatically starts game in the lobby.";

        public override string GetAttributes() => "";

        public override long minimumExecutionDelta => 72;

        public override List<AbstractParameter> GetParameters()
        {
            return new List<AbstractParameter>();
        }

        public override bool Applicable(IController hud)
        {
            return !hud.Game.IsInGame && !hud.Game.IsLoading;
            hud.Render.IsUiElementVisible(UiPathConstants.Buttons.START_GAME);
        }

        public override void Invoke(IController hud)
        {
            var startGameButton = hud.Render.GetOrRegisterAndGetUiElement(UiPathConstants.Buttons.START_GAME);
            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.Buttons.START_GAME);
            startGameButton.Click();
        }
    }
}