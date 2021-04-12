namespace Turbo.plugins.patrick.hotkeys.actions.teleport
{
    using System.Collections.Generic;
    using parameters;
    using Plugins;
    using Plugins.Patrick.forms;
    using util.diablo;
    using util.input;
    using util.thud;

    public class Act5 : AbstractHotkeyAction
    {
        public override HotkeyType type
        {
            get
            {
                return HotkeyType.Teleport;
            }
        }
        
        protected override string GetAttributes()
        {
            return "";
        }

        public override List<AbstractParameter> GetParameters()
        {
            return new List<AbstractParameter>();
        }

        public override bool PreconditionSatisfied(IController hud)
        {
            return hud.Game.CurrentAct != 5;
        }

        protected override void InvokeInternal(IController hud)
        {
            hud.Render.CloseChatAndOpenWindows();
            
            InputSimulator.PressKey(Settings.Keybinds[(int)ActionKey.Map]);
            
            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.WaitpointMap.ZOOM_OUT);
            
            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.WaitpointMap.ACT_FIVE);
            
            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.WaitpointMap.ActFive.TOWN);
        }

    }
}