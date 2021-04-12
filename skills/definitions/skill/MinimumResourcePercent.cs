namespace Turbo.plugins.patrick.skills.definitions.skill
{
    using System.Collections.Generic;
    using parameters;
    using parameters.types;
    using Plugins;

    public class MinimumResourcePercent : AbstractDefinition
    {
        public int minimumResourcePercent { get; set; }

        public override DefinitionType category
        {
            get
            {
                return DefinitionType.Skill;
            }
        }
        public override string attributes
        {
            get
            {
                return $"[ minimumResourcePercent: {minimumResourcePercent} ]";
            }
        }

        public override List<AbstractParameter> GetParameters(IController hud)
        {
            return new List<AbstractParameter>
            {
              SimpleParameter<int>.of(nameof(minimumResourcePercent), x => minimumResourcePercent = x)
            };
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            var resourceType = skill.SnoPower.ResourceCostTypeByRune[skill.Rune == 255 ? 0 : skill.Rune];
            var resourcePercent = resourceType == PowerResourceCostType.primary
                ? hud.Game.Me.Stats.ResourcePctPri
                : hud.Game.Me.Stats.ResourcePctSec;

            return resourcePercent >= minimumResourcePercent;
        }
    }
}