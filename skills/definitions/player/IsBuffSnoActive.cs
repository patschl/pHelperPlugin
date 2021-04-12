namespace Turbo.plugins.patrick.skills.definitions.player
{
    using System.Collections.Generic;
    using parameters;
    using parameters.types;
    using Plugins;

    public class IsBuffSnoActive : AbstractDefinition
    {
        public uint sno { get; set; }

        public override DefinitionType category
        {
            get
            {
                return DefinitionType.Player;
            }
        }

        public override string attributes
        {
            get
            {
                return $"[ Skill Sno: {sno} ]";
            }
        }

        public override List<AbstractParameter> GetParameters(IController hud)
        {
            return new List<AbstractParameter>
            {
                SimpleParameter<int>.of(nameof(sno), x => sno = (uint)x)
            };
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            return hud.Game.Me.Powers.BuffIsActive(sno);
        }
    }
}