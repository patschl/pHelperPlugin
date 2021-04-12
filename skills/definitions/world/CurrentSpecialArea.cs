namespace Turbo.plugins.patrick.skills.definitions.world
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using parameters;
    using parameters.types;
    using Plugins;

    public class CurrentSpecialArea : AbstractDefinition
    {
        public SpecialArea Area { get; set; }

        public override DefinitionType category
        {
            get
            {
                return DefinitionType.World;
            }
        }
        public override string attributes
        {
            get
            {
                return $"[ area: {Area} ]";
            }
        }

        public override List<AbstractParameter> GetParameters(IController hud)
        {
            return new List<AbstractParameter>
            {
                ContextParameter.of(
                    nameof(Area),
                    input => Area = (SpecialArea)input,
                    Enum.GetValues(typeof(SpecialArea)).Cast<Enum>()
                )
            };
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            return hud.Game.SpecialArea == Area;
        }
    }
}