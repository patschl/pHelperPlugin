namespace Turbo.plugins.patrick.hotkeys.actions.town
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using parameters;
    using Plugins;
    using Plugins.Default;
    using util.diablo;
    using util.logger;
    using util.thud;

    public class KanaisCubeUpgradeRares : AbstractHotkeyAction
    {
        public override HotkeyType type => HotkeyType.General;

        protected override string GetAttributes() => "";

        public override List<AbstractParameter> GetParameters()
        {
            return new List<AbstractParameter>();
        }

        public override bool PreconditionSatisfied(IController hud)
        {
            if (!hud.Game.Me.IsInTown || !hud.Render.IsUiElementVisible(UiPathConstants.KanaisCube.RECIPES)) 
                return false;

            var pageNumber = hud.Render.GetOrRegisterAndGetUiElement(UiPathConstants.KanaisCube.PAGE_NUMBER)
                ?.ReadText(System.Text.Encoding.UTF8, true);

            return pageNumber != null && !string.IsNullOrEmpty(pageNumber) && pageNumber.Contains("3");
        }

        public override void Invoke(IController hud)
        {
            hud.Inventory.ItemsInInventory.Where(IsItemUpgradable).ToList().ForEach(item =>
            {
                if (!IsMaterialEnough(hud.Game.Me.Materials)) 
                    return;
                
                hud.Inventory.GetItemRect(item).RightClick();
                hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.KanaisCube.FILL_BUTTON);
                hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.KanaisCube.TRANSMUTE_BUTTON);
                hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.KanaisCube.NEXT_PAGE_BUTTON);
                hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.KanaisCube.PREVIOUS_PAGE_BUTTON);
            });

            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.KanaisCube.CLOSE_BUTTON);
        }

        private static bool IsMaterialEnough(IPlayerMaterialInfo materials)
        {
            return materials.DeathsBreath >= 25 && materials.ReusableParts >= 50 &&
                   materials.ArcaneDust >= 50 && materials.VeiledCrystal >= 50;
        }

        private static bool IsItemUpgradable(IItem item)
        {
            return item.IsRare &&
                   item.SnoItem.Kind == ItemKind.loot &&
                   item.SnoItem.MainGroupCode != "gems_unique" &&
                   item.SnoItem.MainGroupCode != "riftkeystone" &&
                   item.SnoItem.MainGroupCode != "horadriccache" &&
                   item.Quantity <= 1 &&
                   item.SnoItem.Level >= 70;
        }
    }
}