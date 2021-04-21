namespace Turbo.plugins.patrick.skills.definitions.player
{
    using System.Collections.Generic;
    using parameters;
    using parameters.types;
    using Plugins;

    public class MinimumResource : AbstractDefinition
    {
        public bool UsePercentage { get; set; }
        
        public bool UseSecondaryResource { get; set; }
        
        public int MinimumAmount { get; set; }
        
        public override DefinitionType category => DefinitionType.Player;

        public override string attributes => $"[ Minimum {(UseSecondaryResource ? "secondary" : "primary")} resource: {MinimumAmount}{(UsePercentage ? "%" : " (absolute)")} ]";

        public override List<AbstractParameter> GetParameters(IController hud)
        {
            return new List<AbstractParameter>
            {
                SimpleParameter<bool>.of(nameof(UsePercentage), x => UsePercentage = x),
                SimpleParameter<bool>.of(nameof(UseSecondaryResource), x => UseSecondaryResource = x),
                SimpleParameter<int>.of(nameof(MinimumAmount), x => MinimumAmount = x)
            };
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            var resourceAmount = UsePercentage
                ? UseSecondaryResource ? hud.Game.Me.Stats.ResourcePctSec : hud.Game.Me.Stats.ResourcePctPri
                : UseSecondaryResource ? hud.Game.Me.Stats.ResourceCurSec : hud.Game.Me.Stats.ResourceCurPri;

            return resourceAmount >= MinimumAmount;
        }
    }
}