namespace Turbo.plugins.patrick.skills.definitions.skill
{
    using System.Collections.Generic;
    using parameters;
    using parameters.types;
    using Plugins;

    public class HasRuneEquipped : AbstractDefinition
    {
        public string Rune { get; set; }

        public override DefinitionType category => DefinitionType.Skill;

        public override string attributes => $"[ rune: {Rune} ]";

        public override List<AbstractParameter> GetParameters(IController hud)
        {
            return new List<AbstractParameter>
            {
                ContextParameter.of(
                    nameof(Rune),
                    x => Rune = (string)x,
                    hud.Sno.GetSnoPower(definitionGroup.sno)?.RuneNamesEnglish
                )
            };
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            return skill.RuneNameEnglish.Equals(Rune);
        }
    }
}