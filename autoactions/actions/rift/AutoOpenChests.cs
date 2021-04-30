namespace Turbo.plugins.patrick.autoactions.actions.rift
{
    using System.Collections.Generic;
    using System.Linq;
    using parameters;
    using parameters.types;
    using Plugins;
    using util.thud;

    public class AutoOpenChests : AbstractAutoAction
    {
        public int Range { get; set; } = 12;
        public override string GetAttributes() => $"[ Range: {Range}]";
        public override List<AbstractParameter> GetParameters()
        {
            return new List<AbstractParameter> {
                SimpleParameter<int>.of(nameof(Range), x => Range = x),
                };
        }

        public override bool Applicable(IController hud)
        {
            return !hud.Game.IsInTown
                && !hud.Game.Me.IsDead
                && (hud.Game.NormalChests.Any(chest => chest.CentralXyDistanceToMe <= Range) || hud.Game.ResplendentChests.Any(chest => chest.CentralXyDistanceToMe <= Range));

        }

        public override void Invoke(IController hud)
        {
            hud.Game.NormalChests.FirstOrDefault(chest => chest.CentralXyDistanceToMe <= Range)?.Click(hud.Window.Offset);
            hud.Game.ResplendentChests.FirstOrDefault(chest => chest.CentralXyDistanceToMe <= Range)?.Click(hud.Window.Offset);
        }
    }
}