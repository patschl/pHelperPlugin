namespace Turbo.plugins.patrick.hotkeys.actions.general
{
    using System.Collections.Generic;
    using actions;
    using parameters;
    using Plugins;
    using util.diablo;
    using util.thud;

    public class LeaveGame : AbstractHotkeyAction
    {
        public override HotkeyType type
        {
            get
            {
                return HotkeyType.General;
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
            return hud.Game.IsInGame && !hud.Game.IsLoading;
        }

        public override string tooltip
        {
            get
            {
                return "Leaves the game instantly";
            }
        }

        protected override void InvokeInternal(IController hud)
        {
            hud.Render.CloseChatAndOpenWindows();

            var leaveGameButton = hud.Render.GetOrRegisterAndGetUiElement(UiPathConstants.Buttons.LEAVE_GAME);

            if (leaveGameButton.Visible)
            {
                leaveGameButton.Click();
                return;
            }
            
            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.Buttons.GAME_MENU);
            
            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.Buttons.LEAVE_GAME);
        }
    }
}