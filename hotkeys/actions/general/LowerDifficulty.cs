namespace Turbo.plugins.patrick.hotkeys.actions.general
{
    using System;
    using System.Collections.Generic;
    using actions;
    using parameters;
    using Plugins;
    using util.input;
    using util.thud;
    using Settings = Plugins.Patrick.forms.Settings;

    public class LowerDifficulty : AbstractHotkeyAction
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
            throw new NotImplementedException();
        }

        public override bool PreconditionSatisfied(IController hud)
        {
            return hud.Game.GameDifficulty != GameDifficulty.n;
        }

        public override string tooltip
        {
            get
            {
                return "Lowers game difficulty to normal.";
            }
        }

        protected override void InvokeInternal(IController hud)
        {
            try
            {
                var lowerDifficultyButton = hud.Render.GetUiElement(
                    "Root.NormalLayer.gamemenu_dialog.gamemenu_bkgrnd.GameParams.RightButtonStackContainer.button_lowerDifficulty"
                );

                if (!lowerDifficultyButton.Visible)
                {
                    InputSimulator.PressKey(Settings.Keybinds[(int)ActionKey.Close]);
                    
                    hud.Render.GetUiElement(
                        "Root.NormalLayer.GameOptions_main.LayoutRoot.OverlayContainer.KeyBindings.ListContainer.BindingList.HotKeyGameMenu.HotKeyGameMenuText"
                    ).Click();
                }

                while (hud.Game.GameDifficulty != GameDifficulty.n)
                    lowerDifficultyButton.Click();

                hud.Render.GetUiElement("Root.NormalLayer.gamemenu_dialog.gamemenu_bkgrnd.button_resumeGame").Click();
            }
            catch (Exception e)
            {
                hud.Debug(e.ToString());
            }
        }

    }
}