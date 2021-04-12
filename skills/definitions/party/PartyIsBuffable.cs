namespace Turbo.plugins.patrick.skills.definitions.party
{
    using System.Collections.Generic;
    using System.Linq;
    using parameters;
    using Plugins;

    public class PartyIsBuffable : AbstractDefinition
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
            return hud.Game.Players.All(player => !PlayerUnbuffable(hud, player));
        }

        private bool PlayerUnbuffable(IController hud, IPlayer player)
        {
            return player.Powers.BuffIsActive(hud.Sno.SnoPowers.Generic_ActorLoadingBuff.Sno) ||
                   player.Powers.BuffIsActive(hud.Sno.SnoPowers.Generic_ActorGhostedBuff.Sno) ||
                   player.Powers.BuffIsActive(hud.Sno.SnoPowers.Generic_ActorInvulBuff.Sno) ||
                   player.Powers.BuffIsActive(hud.Sno.SnoPowers.Generic_UntargetableDuringBuff.Sno);
        }
    }
}