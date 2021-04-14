namespace Turbo.plugins.patrick.skills.definitions.world
{
    using System.Collections.Generic;
    using System.Linq;
    using parameters;
    using parameters.types;
    using Plugins;

    public class MonstersInRange : AbstractDefinition
    {
        public int Range { get; set; }
        public int Count { get; set; }

        public override DefinitionType category => DefinitionType.World;

        public override string attributes => $"[ range: {Range}, count: {Count} ]";

        public override List<AbstractParameter> GetParameters(IController hud)
        {
            return new List<AbstractParameter>
            {
                SimpleParameter<int>.of(nameof(Range), input => Range = input),
                SimpleParameter<int>.of(nameof(Count), input => Count = input)
            };
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            return hud.Game.AliveMonsters.Count(monster => monster.CentralXyDistanceToMe <= Range) >= Count;
        }
    }
}