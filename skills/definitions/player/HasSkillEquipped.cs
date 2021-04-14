namespace Turbo.plugins.patrick.skills.definitions.player
{
    using System.Collections.Generic;
    using System.Linq;
    using parameters;
    using parameters.types;
    using Plugins;
    using Plugins.Patrick.forms;

    public class HasSkillEquipped : AbstractDefinition
    {
        public uint sno { get; set; }
        
        public string SkillName { get; set; }
        
        public override DefinitionType category => DefinitionType.Player;

        public override string attributes => $"[ SkillName: {SkillName} ]";

        public override List<AbstractParameter> GetParameters(IController hud)
        {
            return new List<AbstractParameter>
            {
                ContextParameter.of(
                    nameof(SkillName),
                    input =>
                    {
                        if (!(input is ISnoPower power))
                            return;
                        SkillName = power.NameEnglish;
                        sno = power.Sno;
                    },
                    Settings.HeroClassToSnoPowers[hud.Game.Me.HeroClassDefinition.HeroClass],
                    "NameEnglish"
                )
            };
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            return hud.Game.Me.Powers.UsedSkills.Any(usedSkill => usedSkill.SnoPower.Sno == sno);
        }
    }
}