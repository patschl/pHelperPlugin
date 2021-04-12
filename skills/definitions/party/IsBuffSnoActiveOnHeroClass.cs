namespace Turbo.plugins.patrick.skills.definitions.party
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using parameters;
    using parameters.types;
    using Plugins;

    public class IsBuffSnoActiveOnHeroClass : AbstractDefinition
    {
        public uint BuffSno { get; set; }

        public HeroClass heroClass { get; set; }

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
                return $"[ BuffSno: {BuffSno} ]";
            }
        }

        public override List<AbstractParameter> GetParameters(IController hud)
        {
            return new List<AbstractParameter>
            {
                ContextParameter.of(
                    nameof(heroClass),
                    input => heroClass = (HeroClass)input,
                    Enum.GetValues(typeof(HeroClass)).Cast<Enum>()
                ),
                SimpleParameter<int>.of(nameof(BuffSno), x => BuffSno = (uint)x)
            };
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            return hud.Game.Players.Any(player => player.HeroClassDefinition.HeroClass == heroClass && player.Powers.BuffIsActive(BuffSno));
        }
        
    }
}