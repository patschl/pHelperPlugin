namespace Turbo.plugins.patrick.autoactions.actions.town {

	using System.Collections.Generic;
	using System.Text;
	using parameters;
	using parameters.types;
	using Plugins;
	using util.diablo;
	using util.thud;

	public class KadalaTab : AbstractAutoAction {
		private static readonly Dictionary<string, string> KadalaTabMapping = new Dictionary<string, string> {
			{ "Weapon/OffHand", UiPathConstants.Vendor.FIRST_TAB },
			{ "Armor", UiPathConstants.Vendor.SECOND_TAB },
			{ "Ring/Amulet", UiPathConstants.Vendor.THIRD_TAB },
		};

		private bool hasMoved = true;

		public string ItemType { get; set; } = "Armor";

		public override string tooltip => "Auto Select Tab at Kadala.";

		public override string GetAttributes() => $"[ Kadala Tab: {ItemType} ]";

		public override List<AbstractParameter> GetParameters() {
			return new List<AbstractParameter> {
				ContextParameter.of(
					nameof(ItemType),
					x => ItemType = (string) x,
					KadalaTabMapping.Keys
				),
			};
		}

		public override bool Applicable(IController hud) {
			if (!hud.Game.IsInTown) return false;

			var kadalaOpen = IsShopOpen(hud) && hud.Render.GetUiElement(UiPathConstants.Vendor.CURRENCY_TYPE).ReadText(Encoding.ASCII, true).Contains("icon:x1_shard");
			if (!kadalaOpen)
				hasMoved = false;

			return kadalaOpen;
		}

		public override void Invoke(IController hud) {
			if (hasMoved) return;
			//Sometimes it doesnt properly register the first click, double clicking just to be sure prevents any accidental buys
			var tabLocation = KadalaTabMapping[ItemType];
			hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(tabLocation);
			hud.Render.GetOrRegisterAndGetUiElement(tabLocation).Click();

			hasMoved = true;
		}

		private static bool IsShopOpen(IController hud) => hud.Render.IsUiElementVisible(UiPathConstants.Vendor.CURRENCY_TYPE);
	}
}
