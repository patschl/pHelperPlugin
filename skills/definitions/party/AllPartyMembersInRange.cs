namespace Turbo.plugins.patrick.skills.definitions.party
{
    using System.Collections.Generic;
    using System.Linq;
    using parameters;
    using parameters.types;
    using Plugins;

    public class AllPartyMembersInRange : AbstractDefinition
    {
        public int range { get; set; }

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
                return $"[ Range: {range} ]";
            }
        }

        public override string tooltip
        {
            get
            {
                return "Checks if all party members are in the given range.";
            }
        }

        public override List<AbstractParameter> GetParameters(IController hud)
        {
            return new List<AbstractParameter>
            {
                SimpleParameter<int>.of(nameof(range), x => range = x)
            };
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            return hud.Game.Players.Count(player => player.CentralXyDistanceToMe < range) == hud.Game.NumberOfPlayersInGame;
        }
    }
}