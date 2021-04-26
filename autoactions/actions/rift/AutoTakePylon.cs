namespace Turbo.plugins.patrick.autoactions.actions.rift
{
    using System.Collections.Generic;
    using System.Linq;
    using parameters;
    using parameters.types;
    using Plugins;
    using util.thud;

    public class AutoTakePylon : AbstractAutoAction
    {
        public bool OnlyIfNemesisEquipped { get; set; }

        public override string GetAttributes() => $"[ Only if nemesis equipped: {OnlyIfNemesisEquipped} ]";

        public override List<AbstractParameter> GetParameters()
        {
            return new List<AbstractParameter> {SimpleParameter<bool>.of(nameof(OnlyIfNemesisEquipped), x => OnlyIfNemesisEquipped = x),};
        }

        public override bool Applicable(IController hud)
        {
            return !hud.Game.Me.IsInTown && !hud.Game.Me.IsDead && hud.Game.Shrines.Any(Matches);
        }

        public override void Invoke(IController hud)
        {
            if (OnlyIfNemesisEquipped && !hud.Game.Me.Powers.BuffIsActive(hud.Sno.SnoPowers.NemesisBracers.Sno))
                return;

            hud.Game.Shrines.FirstOrDefault(pylon => pylon.CentralXyDistanceToMe <= 12)?.Click(hud.Window.Offset);
        }

        private static bool Matches(IShrine shrine)
        {
            return (shrine.IsPylon || shrine.IsShrine) && shrine.IsClickable && !shrine.IsDisabled && !shrine.IsOperated &&
                   shrine.CentralXyDistanceToMe <= 12;
        }
    }
}