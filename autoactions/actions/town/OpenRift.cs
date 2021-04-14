namespace Turbo.plugins.patrick.autoactions.actions.town
{
    using System.Collections.Generic;
    using parameters;
    using parameters.types;
    using Plugins;
    using util.diablo;
    using util.thud;

    public class OpenRift : AbstractAutoAction
    {
        public bool GreaterRift { get; set; }
        
        public bool Empowered { get; set; }

        public override string tooltip
        {
            get
            {
                return "Automatically opens a rift when clicking on the obelisk.";
            }
        }

        public override string GetAttributes()
        {
            return $"[ GreaterRift: {GreaterRift}, Empowered: {Empowered} ]";
        }

        public override List<AbstractParameter> GetParameters()
        {
            return new List<AbstractParameter>
            {
                SimpleParameter<bool>.of(nameof(GreaterRift), x => GreaterRift = x),
                SimpleParameter<bool>.of(nameof(Empowered), x => Empowered = x),
            };
        }

        public override bool Applicable(IController hud)
        {
            return hud.Game.IsInTown && hud.Render.IsUiElementVisible(UiPathConstants.RiftObelisk.OBELISK_WINDOW);
        }

        public override void Invoke(IController hud)
        {
            if (!GreaterRift)
            {
                hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.RiftObelisk.NORMAL_RIFT_BUTTON);
            }
            else
            {
                hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.RiftObelisk.GREATER_RIFT_BUTTON);
                
                var empoweredCheckbox = hud.Render.GetOrRegisterAndGetUiElement(UiPathConstants.RiftObelisk.EMPOWERED_CHECKBOX);
                var animState = empoweredCheckbox.AnimState;
                if ((animState < 7) != Empowered)
                    empoweredCheckbox.Click();
                
                RenderControllerFunctions.WaitForConditionOrAbortHotkeyEvent(() => empoweredCheckbox.AnimState != animState, 1000, 100);
            }

            hud.Render.WaitForVisiblityAndClickOrAbortHotkeyEvent(UiPathConstants.RiftObelisk.ACCEPT_BUTTON);
        }
    }
}