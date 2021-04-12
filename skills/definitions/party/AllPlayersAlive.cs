namespace Turbo.plugins.patrick.skills.definitions.party
{
    using System.Collections.Generic;
    using System.Linq;
    using parameters;
    using Plugins;

    public class AllPlayersAlive : AbstractDefinition
    {
        public override DefinitionType category
        {
            get
            {
                return DefinitionType.Party;
            }
        }

        public override string attributes
        {
            get
            {
                return "";
            }
        }

        public override List<AbstractParameter> GetParameters(IController hud)
        {
            return new List<AbstractParameter>();
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            return hud.Game.Players.Count(player => !player.IsDead) == hud.Game.NumberOfPlayersInGame;
        }
    }
}