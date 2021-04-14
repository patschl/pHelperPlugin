namespace Turbo.plugins.patrick.skills.definitions.world
{
    using System.Collections.Generic;
    using System.Linq;
    using parameters;
    using parameters.types;
    using Plugins;

    public class BossIsSpawned : AbstractDefinition
    {
        public override DefinitionType category => DefinitionType.World;

        public override string attributes => "";

        public override List<AbstractParameter> GetParameters(IController hud)
        {
            return new List<AbstractParameter>();
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            return hud.Game.Monsters.Any(monster => monster.Rarity == ActorRarity.Boss);
        }
    }
}