namespace Turbo.plugins.patrick.autoactions.actions.rift
{
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
            return hud.Game.Me.IsInGame && !hud.Game.Me.IsDead;
        }

        public override void Invoke(IController hud)
        {
            hud.Game.Items.ToList()
                .Where(x => x.Location == ItemLocation.Floor && x.IsOnScreen && Matches(x) && x.CentralXyDistanceToMe < PickupRange)
                .OrderBy(x => x.CentralXyDistanceToMe)
                .First()?.Click();
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
    }
}