namespace Turbo.plugins.patrick.hotkeys.actions.settings
{
    using System.Collections.Generic;
    using parameters;
    using Plugins;
    using Plugins.Patrick.forms;

    public class ToggleActive : AbstractHotkeyAction
    {
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
            Settings.Active = !Settings.Active;
        }
    }
}