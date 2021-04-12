namespace Turbo.plugins.patrick.skills.definitions.party
{
    using System.Collections.Generic;
    using parameters;
    using parameters.types;
    using Plugins;

    public class PlayerCountInParty : AbstractDefinition
    {
        public int playerCountInParty { get; set; }
        
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
                return $"[ Player count: {playerCountInParty} ]";
            }
        }

        public override List<AbstractParameter> GetParameters(IController hud)
        {
            return new List<AbstractParameter>
            {
                SimpleParameter<int>.of(nameof(playerCountInParty), x => playerCountInParty = x)
            };
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            return hud.Game.NumberOfPlayersInGame == playerCountInParty;
        }
    }
}