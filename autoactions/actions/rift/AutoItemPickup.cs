namespace Turbo.plugins.patrick.autoactions.actions.rift
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System;
    using Newtonsoft.Json;
    using parameters.types;
    using parameters;
    using Plugins;
    using util.thud;

    public class AutoItemPickup : AbstractAutoAction
    {
        public bool CraftingMats { get; set; }
        public bool Legendaries { get; set; }
        public int PickupRange { get; set; } = 10;

        [JsonIgnore]
        [Browsable(false)]
        private static readonly HashSet<uint> ItemPickitSet = new HashSet<uint>
        {
            2087837753, // Death's Breath
            2709165134, // Arcane Dust
            3689019703, // Veiled Crystal
            3931359676, // Reusable Parts
            2835237830, // Greater Rift Keystone
            2073430088 // Forgotten Soul
        };

        public override string tooltip => "Automatically picks up configured items.";

        public override string GetAttributes()
        {
            return $"[ {nameof(CraftingMats)}: {CraftingMats}, {nameof(Legendaries)}: {Legendaries}, {nameof(PickupRange)}: {PickupRange} ]";
        }

        public override long minimumExecutionDelta => 64;

        public override List<AbstractParameter> GetParameters()
        {
            return new List<AbstractParameter>
            {
                SimpleParameter<bool>.of(nameof(CraftingMats), x => CraftingMats = x),
                SimpleParameter<bool>.of(nameof(Legendaries), x => Legendaries = x),
                SimpleParameter<int>.of(nameof(PickupRange), x => PickupRange = x),
            };
        }

        public override bool Applicable(IController hud)
        {
            return hud.Game.Me.IsInGame && !hud.Game.Me.IsDead && (hud.Game.Me.InventorySpaceTotal - hud.Game.InventorySpaceUsed != 0 || !Legendaries); // Ignore inventory space if we aren't picking up Legendaries
        }

        public override void Invoke(IController hud)
        {
            if (GetInventorySpaceForTwoSlotItems(hud) != 0 || !Legendaries) // Ignore inventory space if we aren't picking up Legendaries
            {
                hud.Game.Items.ToList()
                    .Where(x => x.Location == ItemLocation.Floor && x.IsOnScreen && Matches(x) && x.CentralXyDistanceToMe < PickupRange)
                    .OrderBy(x => x.CentralXyDistanceToMe)
                    .First()?.Click();
            }
        }

        private bool Matches(IItem item)
        {
            var matches = false;

            if (CraftingMats)
                matches |= ItemPickitSet.Contains(item.SnoItem.Sno);

            if (Legendaries)
                matches |= item.IsLegendary;

            return matches;
        }

        #region Resu.DeluxeInventoryFreeSpacePlugin
        // Original code copied from https://github.com/User5981/Resu/blob/master/DeluxeInventoryFreeSpacePlugin.cs
        private Dictionary<string, string> InventorySlots = new Dictionary<string, string>
        { { "C0R0", string.Empty },
            { "C0R1", string.Empty },
            { "C0R2", string.Empty },
            { "C0R3", string.Empty },
            { "C0R4", string.Empty },
            { "C0R5", string.Empty },
            { "C1R0", string.Empty },
            { "C1R1", string.Empty },
            { "C1R2", string.Empty },
            { "C1R3", string.Empty },
            { "C1R4", string.Empty },
            { "C1R5", string.Empty },
            { "C2R0", string.Empty },
            { "C2R1", string.Empty },
            { "C2R2", string.Empty },
            { "C2R3", string.Empty },
            { "C2R4", string.Empty },
            { "C2R5", string.Empty },
            { "C3R0", string.Empty },
            { "C3R1", string.Empty },
            { "C3R2", string.Empty },
            { "C3R3", string.Empty },
            { "C3R4", string.Empty },
            { "C3R5", string.Empty },
            { "C4R0", string.Empty },
            { "C4R1", string.Empty },
            { "C4R2", string.Empty },
            { "C4R3", string.Empty },
            { "C4R4", string.Empty },
            { "C4R5", string.Empty },
            { "C5R0", string.Empty },
            { "C5R1", string.Empty },
            { "C5R2", string.Empty },
            { "C5R3", string.Empty },
            { "C5R4", string.Empty },
            { "C5R5", string.Empty },
            { "C6R0", string.Empty },
            { "C6R1", string.Empty },
            { "C6R2", string.Empty },
            { "C6R3", string.Empty },
            { "C6R4", string.Empty },
            { "C6R5", string.Empty },
            { "C7R0", string.Empty },
            { "C7R1", string.Empty },
            { "C7R2", string.Empty },
            { "C7R3", string.Empty },
            { "C7R4", string.Empty },
            { "C7R5", string.Empty },
            { "C8R0", string.Empty },
            { "C8R1", string.Empty },
            { "C8R2", string.Empty },
            { "C8R3", string.Empty },
            { "C8R4", string.Empty },
            { "C8R5", string.Empty },
            { "C9R0", string.Empty },
            { "C9R1", string.Empty },
            { "C9R2", string.Empty },
            { "C9R3", string.Empty },
            { "C9R4", string.Empty },
            { "C9R5", string.Empty }
        };

        private int GetInventorySpaceForTwoSlotItems(IController hud)
        {
            var freeTwoSpaceSlots = 0;

            var freeSpace = hud.Game.Me.InventorySpaceTotal - hud.Game.InventorySpaceUsed;
            var squareSide = 0f;

            var itemCheck = hud.Game.Items.FirstOrDefault(i => i.Location == ItemLocation.Inventory);
            if (itemCheck == null)
            {
                freeTwoSpaceSlots = int.MaxValue;
                return freeTwoSpaceSlots;
            }
            else
            {
                var rect = hud.Inventory.GetItemRect(itemCheck);
                squareSide = rect.Width;
            }
            var itemsInInventory = hud.Game.Items.Where(i => i.Location == ItemLocation.Inventory);

            foreach (var key in InventorySlots.Keys.ToList()) // empty dictionary values before filling
            {
                InventorySlots[key] = string.Empty;
            }

            var containerRect = hud.Inventory.InventoryItemsUiElement.Rectangle;
            var firstSquareTop = containerRect.Top;
            var firstSquareLeft = containerRect.Left;
            foreach (var item in itemsInInventory)
            {
                var itemRect = hud.Inventory.GetItemRect(item);

                for (var c = 0; c < 10; c++) // 10 columns
                {
                    for (var r = 0; r < 6; r++) // 6 rows
                    {
                        var datSquareTop = firstSquareTop + (squareSide * r);
                        var datSquareLeft = firstSquareLeft + (squareSide * c);

                        if (Math.Abs(itemRect.Height - squareSide) < 1)
                        {
                            if (Math.Abs(itemRect.Top - datSquareTop) < 4 && Math.Abs(itemRect.Left - datSquareLeft) < 4) //populate inventory slot
                            {
                                var DatKey = "C" + c + "R" + r;
                                InventorySlots[DatKey] = item.SnoItem.Sno.ToString() + item.CreatedAtInGameTick.ToString(); //Item.ItemUniqueId;
                            }
                        }
                        else
                        {
                            if (Math.Abs(itemRect.Top - datSquareTop) < 4 && Math.Abs(itemRect.Left - datSquareLeft) < 4) //populate 2 inventory slots
                            {
                                var datKey = "C" + c + "R" + r;
                                InventorySlots[datKey] = item.SnoItem.Sno.ToString() + item.CreatedAtInGameTick.ToString(); //Item.ItemUniqueId;
                                var datKeyTwo = "C" + c + "R" + (r + 1);
                                InventorySlots[datKeyTwo] = item.SnoItem.Sno.ToString() + item.CreatedAtInGameTick.ToString(); //Item.ItemUniqueId;
                            }
                        }
                    }
                }
            }

            if (squareSide != 0f) // calculate the freeTwoSpaceSlots value
            {
                var twoSlotsCount = 0;
                for (var c = 0; c < 10; c++) // 10 columns
                {
                    for (var r = 0; r < 6; r++) // 6 rows
                    {
                        var datKey = "C" + c + "R" + r;
                        var datValue = InventorySlots[datKey];
                        if (datValue == string.Empty && r < 5)
                        {
                            var datKeyTwo = "C" + c + "R" + (r + 1);
                            var datValueTwo = InventorySlots[datKeyTwo];
                            if (datValueTwo == string.Empty)
                            {
                                twoSlotsCount++;
                                r++;
                            }
                        }
                    }
                }

                freeTwoSpaceSlots = twoSlotsCount;
            }

            return freeTwoSpaceSlots;
        }
    }
    #endregion
}