namespace Turbo.plugins.patrick.skills.definitions.player
{
    using System;
    using System.Collections.Generic;
    using parameters;
    using parameters.types;
    using Plugins;

    public class MinimumHealthPercent : AbstractDefinition
    {
        public int minimumHealthPercent { get; set; }

        public MinimumHealthPercent()
        {
        }

        public MinimumHealthPercent(bool inverted, int minimumHealthPercent) : base(inverted)
        {
            this.minimumHealthPercent = minimumHealthPercent;
        }

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
                return $"[ minimumHealthPercent: {minimumHealthPercent} ]";
            }
        }

        public override List<AbstractParameter> GetParameters(IController hud)
        {
            return new List<AbstractParameter>
            {
                SimpleParameter<int>.of(nameof(minimumHealthPercent), x => minimumHealthPercent = x)
            };
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            return hud.Game.Me.Defense.HealthPct >= minimumHealthPercent;
        }
    }
}