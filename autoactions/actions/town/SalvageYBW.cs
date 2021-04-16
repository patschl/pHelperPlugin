namespace Turbo.plugins.patrick.autoactions.actions.town
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System;
    using parameters.types;
    using parameters;
    using Plugins;
    using util.diablo;
    using util.thud;

    public class SalvageYBW : AbstractAutoAction
    {
        public bool Yellows { get; set; }

        public bool Blues { get; set; }

        public bool Whites { get; set; }

        public override string tooltip => "Automatically salvages Yellow/Blue/White items when visiting the blacksmith";

        public override long minimumExecutionDelta => 2000;

        public override string GetAttributes() => $"[ Yellows: {Yellows}, Blues: {Blues}, Whites: {Whites} ]";

        public override List<AbstractParameter> GetParameters()
        {
            return new List<AbstractParameter>
            {
                SimpleParameter<bool>.of(nameof(Yellows), x => Yellows = x),
                SimpleParameter<bool>.of(nameof(Blues), x => Blues = x),
                SimpleParameter<bool>.of(nameof(Whites), x => Whites = x)
            };
        }

        public override bool Applicable(IController hud)
        {
            if (!hud.Game.IsInTown)
                return false;

            var blacksmithOpen = hud.Render.IsUiElementVisible(UiPathConstants.Blacksmith.UNIQUE_PAGE);

            return blacksmithOpen;
        }

        public override void Invoke(IController hud)
        {
            if (!hud.Inventory.ItemsInInventory.ToList().Any(x => x.IsRare || x.IsMagic || x.IsNormal && x.SnoItem.Kind == ItemKind.loot))
                return;

            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.Blacksmith.SALVAGE_PAGE, 500);

            if (Yellows && hud.Inventory.ItemsInInventory.ToList().Any(x => x.IsRare))
            {
                hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.Blacksmith.SALVAGE_RARE, 500);
                hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.Blacksmith.SALVAGE_DIALOG_OK, 500);
            }
            if (Blues && hud.Inventory.ItemsInInventory.ToList().Any(x => x.IsMagic))
            {
                hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.Blacksmith.SALVAGE_BLUE, 500);
                hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.Blacksmith.SALVAGE_DIALOG_OK, 500);
            }
            if (Whites && hud.Inventory.ItemsInInventory.ToList().Any(x => x.IsNormal && x.SnoItem.Kind == ItemKind.loot))
            {
                hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.Blacksmith.SALVAGE_WHITE, 500);
                hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.Blacksmith.SALVAGE_DIALOG_OK, 500);
            }

            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.Blacksmith.ANVIL);
        }
    }
}