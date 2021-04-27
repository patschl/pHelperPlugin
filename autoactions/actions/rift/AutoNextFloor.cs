namespace Turbo.plugins.patrick.autoactions.actions.rift
{
    using System.Collections.Generic;
    using System.Linq;
    using parameters;
    using parameters.types;
    using Plugins;
    using util.thud;

    public class AutoNextFloor : AbstractAutoAction
    {
        public override string tooltip => "Automatically click the next floor portal in rifts.";

        public override string GetAttributes() => $"";

        public override List<AbstractParameter> GetParameters()
        {
            return new List<AbstractParameter>();
        }

        public override bool Applicable(IController hud)
        {
            if(hud.Game.Portals.Count() == 0)
                return false;
            var closestPortal = hud.Game.Portals.OrderBy(portal => portal.CentralXyDistanceToMe).First();
            var portalTarget = closestPortal.TargetArea.NameEnglish;
            var currentPosition = hud.Game.Me.SnoArea.NameEnglish;
            return !hud.Game.Me.IsDead 
                && (hud.Game.SpecialArea == SpecialArea.GreaterRift || hud.Game.SpecialArea == SpecialArea.Rift)
                && closestPortal.CentralXyDistanceToMe <= 16 
                && portalTarget.Last() > currentPosition.Last();
        }

        public override void Invoke(IController hud)
        {
            hud.Game.Portals.OrderBy(portal => portal.CentralXyDistanceToMe).First().Click(hud.Window.Offset);
        }
    }
}