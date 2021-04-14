namespace Turbo.plugins.patrick.hotkeys.actions.teleport
{
    using System.Collections.Generic;
    using parameters;
    using Plugins;
    using Plugins.Patrick.forms;
    using util.diablo;
    using util.input;
    using util.thud;

    public class Act4 : AbstractHotkeyAction
    {
        public override HotkeyType type => HotkeyType.Teleport;

        protected override string GetAttributes() => "";

        public override List<AbstractParameter> GetParameters()
        {
            return new List<AbstractParameter>();
        }

        public override bool PreconditionSatisfied(IController hud)
        {
            return hud.Game.CurrentAct != 3;
        }

        public override void Invoke(IController hud)
        {
            hud.Render.CloseChatAndOpenWindows();
            
            InputSimulator.PressKey(Settings.Keybinds[(int)ActionKey.Map]);
            
            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.WaitpointMap.ZOOM_OUT);
            
            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.WaitpointMap.ACT_FOUR);
            
            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.WaitpointMap.ActFour.TOWN);
        }

    }
}