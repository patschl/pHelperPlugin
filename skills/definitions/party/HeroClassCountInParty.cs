namespace Turbo.plugins.patrick.skills.definitions.party
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using parameters;
    using parameters.types;
    using Plugins;

    public class NumberOfHeroClassInParty : AbstractDefinition
    {
        public int Count { get; set; }
        
        public HeroClass Class { get; set; }

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
                return $"[ HeroClass: {Class}, Count: {Count} ]";
            }
        }

        public override List<AbstractParameter> GetParameters(IController hud)
        {
            return new List<AbstractParameter>
            {
                ContextParameter.of(
                    nameof(Class),
                    input => Class = (HeroClass)input,
                    Enum.GetValues(typeof(HeroClass)).Cast<Enum>()
                ),
                SimpleParameter<int>.of(nameof(Count), input => Count = input)
            };
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            return hud.Game.Players.Count(player => player.HeroClassDefinition.HeroClass == Class) == Count;
        }
    }
}