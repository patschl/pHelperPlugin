namespace Turbo.plugins.patrick.skills.definitions.itemspecific
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using parameters;
    using parameters.types;
    using Plugins;

    public class CoeRotationOnHeroClass : AbstractDefinition
    {
        public HeroClass Class { get; set; }

        public string Element { get; set; }

        public int TimeLeft { get; set; }

        public override DefinitionType category => DefinitionType.ItemSpecific;

        public override string attributes
        {
            get
            {
                var assembledHeroName = Class == HeroClass.None ? "" : $"Hero: {Class}, ";
                return
                    $"[ {assembledHeroName}Element: {Element}, TimeLeft: {TimeLeft} ]";
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
                ContextParameter.of(
                    nameof(Element),
                    x => Element = (string)x,
                    SnoPowerList.CoeElementToIndex.Keys
                ),
                SimpleParameter<int>.of(nameof(TimeLeft), x => TimeLeft = x, 4000)
            };
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            if (!(hud.Game.Players
                .FirstOrDefault(player =>
                    !player.IsMe && (player.HeroClassDefinition.HeroClass == Class || Class == HeroClass.None) &&
                    player.Powers.BuffIsActive(hud.Sno.SnoPowers.ConventionOfElements.Sno))
                ?.Powers.GetBuff(hud.Sno.SnoPowers.ConventionOfElements.Sno) is IBuff coe))

                return false;

            var elementIndex = SnoPowerList.CoeElementToIndex[Element];
            if (coe.IconCounts[elementIndex] == 0)
                return false;

            return coe.TimeLeftSeconds[elementIndex] < TimeLeft / 1000.0;
        }
    }
}