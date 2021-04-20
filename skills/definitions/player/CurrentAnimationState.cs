namespace Turbo.plugins.patrick.skills.definitions.player
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using parameters;
    using parameters.types;
    using Plugins;

    public class CurrentAnimationState : AbstractDefinition
    {

        public AcdAnimationState AnimationState { get; set; }

        public override DefinitionType category => DefinitionType.Player;

        public override string attributes => $"[ AnimationState: {AnimationState} ]";
        
        public override List<AbstractParameter> GetParameters(IController hud)
        {
            return new List<AbstractParameter>
            {
                ContextParameter.of(
                    nameof(AnimationState),
                    input => AnimationState = (AcdAnimationState)input,
                    Enum.GetValues(typeof(AcdAnimationState)).Cast<Enum>()
                )
            };
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            return hud.Game.Me.AnimationState == AnimationState;
        }
    }
}