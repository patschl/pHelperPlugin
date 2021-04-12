namespace Turbo.plugins.patrick.skills.definitions.world
{
    using System.Collections.Generic;
    using System.Linq;
    using parameters;
    using parameters.types;
    using Plugins;

    public class EliteInRange : AbstractDefinition
    {
        
        public int MinimumAmount { get; set; }
        
        public int Range { get; set; }
        
        public override DefinitionType category
        {
            get
            {
                return DefinitionType.World;
            }
        }

        public override string attributes
        {
            get
            {
                return $"[ Minimum amount: {MinimumAmount}, Range: {Range} ]";
            }
        }

        public override List<AbstractParameter> GetParameters(IController hud)
        {
            return new List<AbstractParameter>
            {
                SimpleParameter<int>.of(nameof(MinimumAmount), x => MinimumAmount = x),
                SimpleParameter<int>.of(nameof(Range), x => Range = x)
            };
            
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            return hud.Game.AliveMonsters.Count(mon => IsElite(mon) && mon.CentralXyDistanceToMe <= Range) >= MinimumAmount;
        }

        private static bool IsElite(IMonster monster)
        {
            return monster.Rarity == ActorRarity.Champion || monster.Rarity == ActorRarity.Rare || monster.Rarity == ActorRarity.Unique ||
                   monster.Rarity == ActorRarity.Boss;
        }
    }
}