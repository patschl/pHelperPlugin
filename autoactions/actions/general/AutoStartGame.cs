namespace Turbo.plugins.patrick.autoactions.actions.town
{
	using System.Collections.Generic;
	using System.Text;
	using parameters;
	using parameters.types;
	using Plugins;
	using util.diablo;
	using util.thud;

	public class AutoStartGame : AbstractAutoAction
	{
		public override string tooltip => "Automatically starts game in the lobby.";

		public override string GetAttributes() => $"[ Text On Game Start Button: {TextOnButton} ]";

		public override long minimumExecutionDelta => 500;

		public string TextOnButton { get; set; } = "Start";

		public override List<AbstractParameter> GetParameters()
		{
			return new List<AbstractParameter> {
				SimpleParameter<string>.of(nameof(TextOnButton), x => TextOnButton = x)
			};
		}

		public override bool Applicable(IController hud)
		{
			return !hud.Game.IsInGame
			&& !hud.Game.IsLoading
			&& hud.Render.IsUiElementVisible(UiPathConstants.Buttons.START_GAME)
			&& hud.Render.GetUiElement(UiPathConstants.Buttons.START_GAME)
				  .ReadText(Encoding.UTF8, true).Contains(TextOnButton);
		}

		public override void Invoke(IController hud)
		{
			hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.Buttons.START_GAME);
		}
	}
}
