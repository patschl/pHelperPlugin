namespace Turbo.plugins.patrick.hotkeys.actions.teleport
{
    using System.Collections.Generic;
    using actions;
    using hotkeys;
    using parameters;
    using Plugins;
    using Plugins.Patrick.forms;
    using util.diablo;
    using util.input;
    using util.thud;

    public class Act2 : AbstractHotkeyAction
    {
        public override HotkeyType type => HotkeyType.Teleport;

        protected override string GetAttributes() => "";

        public override List<AbstractParameter> GetParameters()
        {
            return new List<AbstractParameter>();
        }

        public override bool PreconditionSatisfied(IController hud)
        {
            return hud.Game.CurrentAct != 2;
        }

        public override void Invoke(IController hud)
        {
            hud.Render.CloseChatAndOpenWindows();
            
            InputSimulator.PressKey(Settings.Keybinds[(int)ActionKey.Map]);
            
            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.WaitpointMap.ZOOM_OUT);
            
            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.WaitpointMap.ACT_TWO);
            
            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.WaitpointMap.ActTwo.TOWN);
        }

    }
}