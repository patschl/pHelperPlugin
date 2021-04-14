namespace Turbo.plugins.patrick.skills.definitions.world
{
    using System.Collections.Generic;
    using System.Linq;
    using parameters;
    using parameters.types;
    using Plugins;

    public class MonstersInRange : AbstractDefinition
    {
        public int MinimumAmount { get; set; }
        
        public int Range { get; set; }

        public override DefinitionType category => DefinitionType.World;

        public override string attributes => $"[ Minimum amount: {MinimumAmount}, Range: {Range} ]";

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
            return hud.Game.AliveMonsters.Count(monster => monster.CentralXyDistanceToMe <= Range) >= MinimumAmount;
        }
    }
}