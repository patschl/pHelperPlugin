namespace Turbo.plugins.patrick.hotkeys.actions.general {

	using System;
	using System.Collections.Generic;
	using actions;
	using hotkeys;
	using parameters;
	using Plugins;
	using Plugins.Default;
	using Plugins.Patrick.forms;
	using util.diablo;
	using util.input;
	using util.thud;

	public class KadalaGamble : AbstractHotkeyAction {
		private static string[] ItemLocationMapping = new[] {
			UiPathConstants.Vendor.FIRST_ITEM,
			UiPathConstants.Vendor.SECOND_ITEM,
			UiPathConstants.Vendor.THIRD_ITEM,
			UiPathConstants.Vendor.FOURTH_ITEM,
			UiPathConstants.Vendor.FIFTH_ITEM,
			UiPathConstants.Vendor.SIXTH_ITEM,
			UiPathConstants.Vendor.SEVENTH_ITEM,
			UiPathConstants.Vendor.EIGHTH_ITEM,
			UiPathConstants.Vendor.NINTH_ITEM,
		};

		public override HotkeyType type => HotkeyType.General;

		protected override string GetAttributes() => "";

		public override List<AbstractParameter> GetParameters() {
			return new List<AbstractParameter>();
		}

		public override bool PreconditionSatisfied(IController hud) {
			return hud.Game.Me.IsInTown && IsShopOpen(hud)
				   && hud.Render.GetUiElement(UiPathConstants.Vendor.CURRENCY_TYPE).ReadText(System.Text.Encoding.ASCII, true).Contains("icon:x1_shard");
		}

		public override string tooltip => "Gamble on Kadala";

		public override void Invoke(IController hud) {
			var failSelect = true;
			IUiElement selectUI = null;
			for (var i = 0; i < ItemLocationMapping.Length; i++) {
				selectUI = hud.Render.GetOrRegisterAndGetUiElement(ItemLocationMapping[i]);
				if (selectUI == null || !selectUI.Visible) continue;

				if (hud.Window.CursorInsideRect(selectUI.Rectangle.X, selectUI.Rectangle.Y, selectUI.Rectangle.Width, selectUI.Rectangle.Height)) {
					failSelect = false;
					break;
				}
			}

			if (failSelect) return;

			var maxItems = 120;
			for (var i = 0; i < --maxItems; i++) {
				if (!IsShopOpen(hud)) return;

				selectUI.RightClick();
			}

			if (IsShopOpen(hud))
				hud.Render.GetOrRegisterAndGetUiElement(UiPathConstants.Vendor.CLOSE_BUTTON).Click();

			hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.Buttons.INVENTORY);
		}

		private static bool IsShopOpen(IController hud) => hud.Render.IsUiElementVisible(UiPathConstants.Vendor.CURRENCY_TYPE);
	}
}