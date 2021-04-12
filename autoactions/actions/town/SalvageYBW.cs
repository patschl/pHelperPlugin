namespace Turbo.plugins.patrick.autoactions.actions.town
{
    using System.Collections.Generic;
    using parameters;
    using parameters.types;
    using Plugins;
    using util.diablo;
    using util.thud;

    public class SalvageYBW : AbstractAutoAction
    {
        public bool Yellows { get; set; }
        
        public bool Blues { get; set; }
        
        public bool Whites { get; set; }

        public override string tooltip
        {
            get
            {
                return "Automatically salvages Yellow/Blue/White items when visiting the blacksmith";
            }
        }

        public override string GetAttributes()
        {
            return $"[ Yellows: {Yellows}, Blues: {Blues}, Whites: {Whites} ]";
        }

        public override List<AbstractParameter> GetParameters()
        {
            return new List<AbstractParameter>
            {
                SimpleParameter<bool>.of(nameof(Yellows), x => Yellows = x),
                SimpleParameter<bool>.of(nameof(Blues), x => Blues = x),
                SimpleParameter<bool>.of(nameof(Whites), x => Whites = x)
            };
        }

        public override bool Applicable(IController hud)
        {
            return hud.Game.Me.IsInTown && hud.Render.IsUiElementVisible(UiPathConstants.Blacksmith.VENDOR_WINDOW);
        }

        public override void Invoke(IController hud)
        {
            // todo
        }
    }
}