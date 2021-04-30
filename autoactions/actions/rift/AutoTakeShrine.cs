namespace Turbo.plugins.patrick.autoactions.actions.rift
{
    using System.Collections.Generic;
    using System.Linq;
    using parameters;
    using parameters.types;
    using Plugins;
    using util.thud;

    public class AutoTakeShrine : AbstractAutoAction
    {
        public bool HealingWell { get; set; }
        public bool PoolOfReflection { get; set; }
        public int Range { get; set; } = 5;

        public override string GetAttributes() => $"[ HealingWell: {HealingWell} PoolOfReflection: {PoolOfReflection} Range: {Range}]";

        public override List<AbstractParameter> GetParameters()
        {
            return new List<AbstractParameter> {
                SimpleParameter<bool>.of(nameof(HealingWell), x => HealingWell = x),
                SimpleParameter<bool>.of(nameof(PoolOfReflection), x => PoolOfReflection = x),
                SimpleParameter<int>.of(nameof(Range), x => Range = x),
                };
        }

        public override bool Applicable(IController hud)
        {
            return !hud.Game.Me.IsInTown && !hud.Game.Me.IsDead && hud.Game.Shrines.Any(shrine => Matches(shrine) && shrine.CentralXyDistanceToMe <= Range);
        }

        public override void Invoke(IController hud)
        {
            hud.Game.Shrines.FirstOrDefault(shrine => shrine.CentralXyDistanceToMe <= Range
                                                   && ((HealingWell && shrine.IsHealingWell)
                                                    || (PoolOfReflection && shrine.IsPoolOfReflection))
                            )?.Click(hud.Window.Offset);
        }

        private static bool Matches(IShrine shrine)
        {
            return (shrine.IsHealingWell || shrine.IsPoolOfReflection) &&
                shrine.IsClickable && !shrine.IsDisabled && !shrine.IsOperated;
        }
    }
}