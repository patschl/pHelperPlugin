namespace Turbo.plugins.patrick.autoactions.actions.town
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Turbo.plugins.patrick.util.input;
    using parameters;
    using parameters.types;
    using Plugins;
    using util.diablo;
    using util.thud;

    public class AutoMainstat : AbstractAutoAction
    {
        public bool Vitality { get; set; }

        public override string tooltip => "Automatically assigns mainstat in town.";
        
        public override string GetAttributes() =>  $"[ Vitality: {Vitality}]";

        public override List<AbstractParameter> GetParameters()
        {
            return new List<AbstractParameter>
            {
                SimpleParameter<bool>.of(nameof(Vitality), x => Vitality = x)
            };
        }

        public override bool Applicable(IController hud)
        {
            return hud.Game.IsInTown && hud.Render.IsUiElementVisible(UiPathConstants.Paragon.NEW_PARAGON_BUTTON);
        }

        public override void Invoke(IController hud)
        {
            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.Paragon.NEW_PARAGON_BUTTON);
            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.Paragon.PARAGON_TAB_CORE);
            var paragonAvailable = Double.Parse(hud.Render.GetUiElement(UiPathConstants.Paragon.PARAGON_UNSPENT_CORE).ReadText(System.Text.Encoding.ASCII, true));
            var amountOfClicks = (int) Math.Ceiling(paragonAvailable / 100);

            if (amountOfClicks == 0)
            {
                hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.Paragon.PARAGON_BUTTON_CLOSE);
            }

            InputSimulator.PostMessageKeyDown(Keys.ControlKey);
            for (int i = 0; i < amountOfClicks; i++)
            {
                if (Vitality)
                {
                    hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.Paragon.PARAGON_BUTTON_SECOND);
                }
                else
                {
                    hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.Paragon.PARAGON_BUTTON_FIRST);
                }
            }
            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.Paragon.PARAGON_BUTTON_ACCEPT);
            //Call keyUp after closing the interface because it can block the accept button click going through
            InputSimulator.PostMessageKeyUp(Keys.ControlKey);
        }
    }
}