namespace Turbo.plugins.patrick.autoactions.actions.town
{
    using System.Collections.Generic;
    using System.Text;
    using parameters;
    using parameters.types;
    using Plugins;
    using util.diablo;
    using util.thud; 

    public class Kadala : AbstractAutoAction
    {
        private const string BIG = "BIG";

        private static readonly Dictionary<string, string[]> ItemLocationMapping = new Dictionary<string, string[]>
        {
            {"1-H Weapon", new[] {UiPathConstants.Vendor.FIRST_ITEM, UiPathConstants.Vendor.FIRST_TAB, BIG}},
            {"2-H Weapon", new[] {UiPathConstants.Vendor.SECOND_ITEM, UiPathConstants.Vendor.FIRST_TAB, BIG}},
            {"Quiver", new[] {UiPathConstants.Vendor.THIRD_ITEM, UiPathConstants.Vendor.FIRST_TAB, BIG}},
            {"Orb", new[] {UiPathConstants.Vendor.FOURTH_ITEM, UiPathConstants.Vendor.FIRST_TAB, BIG}},
            {"Mojo", new[] {UiPathConstants.Vendor.FIFTH_ITEM, UiPathConstants.Vendor.FIRST_TAB, BIG}},
            {"Phylactery", new[] {UiPathConstants.Vendor.SIXTH_ITEM, UiPathConstants.Vendor.FIRST_TAB, BIG}},
            {"Helm", new[] {UiPathConstants.Vendor.FIRST_ITEM, UiPathConstants.Vendor.SECOND_TAB, BIG}},
            {"Gloves", new[] {UiPathConstants.Vendor.SECOND_ITEM, UiPathConstants.Vendor.SECOND_TAB, BIG}},
            {"Boots", new[] {UiPathConstants.Vendor.THIRD_ITEM, UiPathConstants.Vendor.SECOND_TAB, BIG}},
            {"Chest Armor", new[] {UiPathConstants.Vendor.FOURTH_ITEM, UiPathConstants.Vendor.SECOND_TAB, BIG}},
            {"Belt", new[] {UiPathConstants.Vendor.FIFTH_ITEM, UiPathConstants.Vendor.SECOND_TAB, null}},
            {"Shoulders", new[] {UiPathConstants.Vendor.SIXTH_ITEM, UiPathConstants.Vendor.SECOND_TAB, BIG}},
            {"Pants", new[] {UiPathConstants.Vendor.SEVENTH_ITEM, UiPathConstants.Vendor.SECOND_TAB, BIG}},
            {"Bracers", new[] {UiPathConstants.Vendor.EIGHTH_ITEM, UiPathConstants.Vendor.SECOND_TAB, BIG}},
            {"Shield", new[] {UiPathConstants.Vendor.NINTH_ITEM, UiPathConstants.Vendor.SECOND_TAB, BIG}},
            {"Ring", new[] {UiPathConstants.Vendor.FIRST_ITEM, UiPathConstants.Vendor.THIRD_TAB, null}},
            {"Amulet", new[] {UiPathConstants.Vendor.SECOND_ITEM, UiPathConstants.Vendor.THIRD_TAB, null}}
        };

        public string Item { get; set; } = "1-H Weapon";

        public override string tooltip => "Auto gamble items at Kadala.";

        public override string GetAttributes() => $"[ Item: {Item} ]";

        public override List<AbstractParameter> GetParameters()
        {
            return new List<AbstractParameter>
            {
                ContextParameter.of(
                    nameof(Item),
                    x => Item = (string) x,
                    ItemLocationMapping.Keys
                ),
            };
        }

        public override bool Applicable(IController hud)
        {
            return hud.Game.Me.IsInTown
                   && IsShopOpen(hud)
                   && hud.Render.GetUiElement(UiPathConstants.Vendor.CURRENCY_TYPE)
                       .ReadText(Encoding.ASCII, true).Contains("icon:x1_shard");
        }

        //Since a user can close the Kadala interface unexpectedly we check before each action if the shop is still open
        //if not we return early, this is to prevent randomly moving the user's character around
        public override void Invoke(IController hud)
        {
            //Sometimes it doesnt properly register the first click, double clicking just to be sure prevents any accidental buys
            var itemLocation = ItemLocationMapping[Item];
            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(itemLocation[1]);
            hud.Render.GetOrRegisterAndGetUiElement(itemLocation[1]).Click();

            var maxItems = 120;

            hud.Render.WaitForVisiblityAndRightClickOrAbortHotkeyEvent(itemLocation[0]);
            for (var i = 0; i < --maxItems; i++)
            {
                if (!IsShopOpen(hud))
                    return;
                hud.Render.GetOrRegisterAndGetUiElement(itemLocation[0]).RightClick();
            }

            if (IsShopOpen(hud))
                hud.Render.GetOrRegisterAndGetUiElement(UiPathConstants.Vendor.CLOSE_BUTTON).Click();
            
            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.Buttons.INVENTORY);
        }

        private static bool IsShopOpen(IController hud) => hud.Render.IsUiElementVisible(UiPathConstants.Vendor.CURRENCY_TYPE);
    }
}
