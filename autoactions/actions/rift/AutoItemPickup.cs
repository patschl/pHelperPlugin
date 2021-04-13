namespace Turbo.plugins.patrick.autoactions.actions.rift
{
    using System.Collections.Generic;
    using System.Linq;
    using parameters.types;
    using parameters;
    using Plugins;
    using util.thud;

    public class AutoItemPickup : AbstractAutoAction
    {
        public bool CraftingMats { get; set; }
        public bool Legendaries { get; set; }
        public int PickupRange { get; set; } = 10;
        public override string tooltip
        {
            get
            {
                return "Automatically picks up configured items.";
            }
        }

        public override string GetAttributes()
        {
            return $"[ {nameof(CraftingMats)}: {CraftingMats}, {nameof(Legendaries)}: {Legendaries}, {nameof(PickupRange)}: {PickupRange} ]";
        }

        public override long minimumExecutionDelta => 250;

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
            return hud.Game.Me.IsInGame && (!hud.Game.Me.IsInTown || ItemsClickedAlready.Any()) && !hud.Game.Me.IsDead;
        }

        public override void Invoke(IController hud)
        {
            // if (hud.Game.Me.IsInTown) {
            //     ItemsClickedAlready.Clear();
            // }
            foreach (var item in hud.Game.Items.Where(x => x.Location == ItemLocation.Floor && x.IsOnScreen && Matches(x)).OrderBy(x => x.CentralXyDistanceToMe))
            {
                if (item.CentralXyDistanceToMe < PickupRange)
                {
                    item.Click();
                    ItemsClickedAlready.Add(item.FloorCoordinate.ToString());
                }
            }
        }

        private List<string> ItemsClickedAlready = new List<string>(); //This seems like a bad idea and will probably memory leak..

        private bool Matches(IItem item)
        {
            HashSet<uint> itemPickitSet = new HashSet<uint>
            {
                2087837753, // Death's Breath
                2709165134, // Arcane Dust
                3689019703, // Veiled Crystal
                3931359676, // Reusable Parts
                2835237830, // Greater Rift Keystone
                2073430088 // Forgotten Soul
            };
            var matches = false;

            if (CraftingMats)
            {
                matches |= itemPickitSet.Contains(item.SnoItem.Sno);
            }

            if (Legendaries)
            {
                matches |= item.IsLegendary;
            }

            // if(ItemsClickedAlready.Contains(item.FloorCoordinate.ToString())){
            //     matches = false;
            // }

            return matches;
        }
    }
}