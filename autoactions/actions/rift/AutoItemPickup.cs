namespace Turbo.plugins.patrick.autoactions.actions.rift
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Newtonsoft.Json;
    using parameters.types;
    using parameters;
    using Plugins;
    using util.thud;

    public class AutoItemPickup : AbstractAutoAction
    {
        public bool CraftingMats { get; set; }
        
        public bool Legendaries { get; set; }
        
        public bool Jewels { get; set; }
            
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

        [JsonIgnore]
        [Browsable(false)]
        private bool twoUnitSlotAvailable = true; 
        
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
                SimpleParameter<bool>.of(nameof(Jewels), x => Jewels = x),
                SimpleParameter<int>.of(nameof(PickupRange), x => PickupRange = x),
            };
        }

        public override bool Applicable(IController hud)
        {
            CheckInventorySpace(hud);

            return hud.Game.Me.IsInGame && !hud.Game.Me.IsDead && hud.Game.Items.ToList().Any(item => item.CentralXyDistanceToMe < PickupRange && !item.AccountBound && !item.SeenInInventory);
        }

        public override void Invoke(IController hud)
        {
            hud.Game.Items.ToList()
                .Where(x => x.Location == ItemLocation.Floor && Matches(x) && x.CentralXyDistanceToMe < PickupRange && !x.AccountBound && !x.SeenInInventory)
                .OrderBy(x => x.CentralXyDistanceToMe)
                .FirstOrDefault(item => !item.IsLegendary || (item.SnoItem.ItemHeight == 1 && hud.Game.Me.InventorySpaceTotal - hud.Game.InventorySpaceUsed > 1) || twoUnitSlotAvailable)?.Click();
        }

        private bool Matches(IItem item)
        {
            var matches = false;

            if (CraftingMats)
                matches |= ItemPickitSet.Contains(item.SnoItem.Sno);

            if (Legendaries)
                matches |= item.IsLegendary;

            if (Jewels)
                matches |= item.SnoItem.Kind == ItemKind.gem;

            return matches;
        }

        private void CheckInventorySpace(IController hud)
        {
            if (!Legendaries || (hud.Game.Me.InventorySpaceTotal - hud.Game.InventorySpaceUsed > 30))
            {
                twoUnitSlotAvailable = true;
                return;
            }

            var inventoryCoords = new Dictionary<int, List<int>>();
            hud.Inventory.ItemsInInventory.ToList().ForEach(item =>
            {
                if (inventoryCoords.ContainsKey(item.InventoryX))
                    inventoryCoords[item.InventoryX].Add(item.InventoryY);
                else 
                    inventoryCoords.Add(item.InventoryX, new List<int>{item.InventoryY});
                
                if (item.SnoItem.ItemHeight == 2)
                    inventoryCoords[item.InventoryX].Add(item.InventoryY + 1);
            });

            twoUnitSlotAvailable = inventoryCoords.Count < 10;

            if (!twoUnitSlotAvailable)
                twoUnitSlotAvailable = inventoryCoords.Any(item =>
                {
                    for (var i = 0; i < 5; i++)
                        if (!item.Value.Contains(i) && !item.Value.Contains(i + 1))
                            return true;

                    return false;
                });
        }
    }
}