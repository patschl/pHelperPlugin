namespace Turbo.plugins.patrick.skills.definitions.itemspecific
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using parameters;
    using parameters.types;
    using Plugins;

    public class CoeRotation : AbstractDefinition
    {
        [JsonIgnore] private static readonly Dictionary<string, int> CoeElementToIndex = new Dictionary<string, int>
        {
            {"Cold", 1},
            {"Arcane", 2},
            {"Fire", 3},
            {"Holy", 4},
            {"Lightning", 5},
            {"Physical", 6},
            {"Poison", 7}
        };

        public string Element { get; set; }
        
        public int TimeLeft { get; set; }

        public override DefinitionType category => DefinitionType.ItemSpecific;

        public override string attributes => $"[ Element: {Element}, TimeLeft: {TimeLeft} ]";

        public override List<AbstractParameter> GetParameters(IController hud)
        {
            return new List<AbstractParameter>
            {
                ContextParameter.of(
                    nameof(Element),
                    x => Element = (string)x,
                    CoeElementToIndex.Keys
                ),
                SimpleParameter<int>.of(nameof(TimeLeft), x => TimeLeft = x, 4000)
            };
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            if (!hud.Game.Me.Powers.BuffIsActive(hud.Sno.SnoPowers.ConventionOfElements.Sno))
                return false;

            var buff = hud.Game.Me.Powers.GetBuff(hud.Sno.SnoPowers.ConventionOfElements.Sno);
            var elementIndex = CoeElementToIndex[Element];
            if (buff.IconCounts[elementIndex] == 0)
                return false;

            return buff.TimeLeftSeconds[elementIndex] < TimeLeft / 1000.0;
        }
    }
}