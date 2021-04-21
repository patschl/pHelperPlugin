namespace Turbo.plugins.patrick.hotkeys.actions.settings
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using parameters;
    using Plugins;
    using util.thud;

    public class ToggleActivePowerOverlay : AbstractHotkeyAction
    {

        [JsonIgnore] private ActivePowerOverlay activePowerOverlay;
        
        public override HotkeyType type => HotkeyType.Settings;

        protected override string GetAttributes() => "";

        public override List<AbstractParameter> GetParameters()
        {
            return new List<AbstractParameter>();
        }

        public override bool PreconditionSatisfied(IController hud)
        {
            return true;
        }

        public override void Invoke(IController hud)
        {
            if (activePowerOverlay == null)
                activePowerOverlay = hud.GetPlugin<ActivePowerOverlay>();

            activePowerOverlay.Reset();
            activePowerOverlay.Enabled = !activePowerOverlay.Enabled;
        }
    }
}