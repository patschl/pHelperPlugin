namespace Turbo.plugins.patrick.skills.definitions.party
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using parameters;
    using parameters.types;
    using Plugins;
    using Plugins.Patrick.forms;

    public class HeroClassHasSkillEquipped : AbstractDefinition
    {
        public HeroClass Class { get; set; }
        
        public uint sno { get; set; }

        public string SkillName { get; set; }
        
        public override DefinitionType category => DefinitionType.Party;

        public override string attributes => $"[ HeroClass: {Class}, Skill: {SkillName} ]";

        public override List<AbstractParameter> GetParameters(IController hud)
        {
            return new List<AbstractParameter>
            {
                ContextParameter.of(
                    nameof(Class),
                    input => Class = (HeroClass)input,
                    Enum.GetValues(typeof(HeroClass)).Cast<Enum>()
                ),
                ContextParameter.of(
                    nameof(SkillName),
                    input =>
                    {
                        if (!(input is ISnoPower power))
                            return;
                        SkillName = power.NameEnglish;
                        sno = power.Sno;
                    },
                    Settings.HeroClassToSnoPowers[HeroClass.None],
                    "NameEnglish"
                )
            };
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            return hud.Game.Players.Where(player => player.HeroClassDefinition.HeroClass == Class)
                .Any(player => player.Powers.UsedSkills.Any(s => s.SnoPower.Sno == sno));
        }
    }
}