namespace Turbo.plugins.patrick.autoactions.actions.rift
{
    using System.Collections.Generic;
    using parameters;
    using parameters.types;
    using Plugins;
    using util.thud;

    public class Potion : AbstractAutoAction
    {
        public int HealthPercent { get; set; } = 40;

        public override string GetAttributes() => $"[ HealthPercent: {HealthPercent} ]";

        public override List<AbstractParameter> GetParameters()
        {
            return new List<AbstractParameter>
            {
                SimpleParameter<int>.of(nameof(HealthPercent), x => HealthPercent = x)
            };
        }

        public override bool Applicable(IController hud)
        {
            var shouldHeal =  hud.Game.IsInGame
                              && !hud.Game.IsInTown
                              && !hud.Game.IsLoading
                              && hud.Game.MapMode == MapMode.Minimap
                              && !hud.Game.Me.IsDead
                              && hud.Game.Me.AnimationState != AcdAnimationState.CastingPortal;

            return shouldHeal && !hud.Game.Me.Powers.HealthPotionSkill.IsOnCooldown && hud.Game.Me.Defense.HealthPct <= HealthPercent;
        }

        public override void Invoke(IController hud)
        {
            hud.Game.Me.Powers.HealthPotionSkill.Cast();
        }
    }
}