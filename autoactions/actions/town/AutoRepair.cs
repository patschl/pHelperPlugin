namespace Turbo.plugins.patrick.autoactions.actions.town
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using parameters;
    using Plugins;
    using util.diablo;
    using util.thud;

    public class AutoRepair : AbstractAutoAction
    {
        public override string tooltip => "Will automatically repair at the blacksmith.";

        public override string GetAttributes() => "";

        public override long minimumExecutionDelta => 2000;

        public override List<AbstractParameter> GetParameters()
        {
            return new List<AbstractParameter>();
        }

        public override bool Applicable(IController hud)
        {
            if (!hud.Game.Me.IsInTown || !hud.Render.IsUiElementVisible(UiPathConstants.Blacksmith.UNIQUE_PAGE))
                return false;

            if (!AnyDamagedItems(hud))
            {
                return false;
            }

            return true;
        }

        public override void Invoke(IController hud)
        {
            var goldCostElement = hud.Render.GetOrRegisterAndGetUiElement(UiPathConstants.Blacksmith.REPAIR_ALL);
            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.Blacksmith.REPAIR_PAGE, 500);
            var goldCost = GetGoldCost(goldCostElement);
            if (goldCost > hud.Game.Me.Materials.Gold)
            {
                // We can't afford to repair, let's not try and end up in a repair loop.
                return;
            }

            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.Blacksmith.REPAIR_ALL, 250);
        }

        private static long GetGoldCost(IUiElement repairAll)
        {
            var goldCostText = repairAll?.ReadText(System.Text.Encoding.ASCII, true);
            var extractedGoldCost = GoldRegex.Match(goldCostText);
            long.TryParse(extractedGoldCost.Value?.Trim(), out var goldCost);
            return goldCost;
        }

        private static Regex GoldRegex = new Regex(@".(\d+).");

        private bool AnyDamagedItems(IController hud)
        {
            var equippedItems = hud.Game.Items.Where(i => i.Location == ItemLocation.Head || i.Location == ItemLocation.Torso || i.Location == ItemLocation.Torso ||
                i.Location == ItemLocation.RightHand || i.Location == ItemLocation.LeftHand || i.Location == ItemLocation.Hands || i.Location == ItemLocation.Waist ||
                i.Location == ItemLocation.Feet || i.Location == ItemLocation.Shoulders || i.Location == ItemLocation.Legs || i.Location == ItemLocation.Bracers ||
                i.Location == ItemLocation.LeftRing || i.Location == ItemLocation.RightRing || i.Location == ItemLocation.Neck);
            foreach (var item in equippedItems)
            {
                var currentDurability = item.StatList.FirstOrDefault(i => i.Id.Contains("Durability_Cur"))?.DoubleValue;
                var maxDurability = item.StatList.FirstOrDefault(i => i.Id.Contains("Durability_Max"))?.DoubleValue;
                if (currentDurability != maxDurability)
                    return true; // Return as soon as we find just one item damaged
            }
            return false;
        }
    }
}