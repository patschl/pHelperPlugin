namespace Turbo.plugins.patrick.skills.definitions.player
{
    using System.Collections.Generic;
    using parameters;
    using parameters.types;
    using Plugins;
    using Plugins.Patrick.forms;

    public class IsSkillBuffActive : AbstractDefinition
    {
        public string BuffName { get; set; }
        
        public uint SelectedSno { get; set; }
        
        public uint Sno { get; set; }
        
        public bool OverrideSelectedWithSno { get; set; }

        public override DefinitionType category
        {
            get
            {
                return DefinitionType.Player;
            }
        }

        public override string attributes
        {
            get
            {
                return $"[ BuffName: {BuffName}, OverrideSelectedBuff: {OverrideSelectedWithSno}, SnoId: {Sno} ]";
            }
        }

        public override List<AbstractParameter> GetParameters(IController hud)
        {
            return new List<AbstractParameter>
            {
                ContextParameter.of(
                    nameof(BuffName),
                    input =>
                    {
                        if (!(input is KeyValuePair<string, ISnoPower> pair))
                            return;
                        BuffName = pair.Key;
                        SelectedSno = pair.Value.Sno;
                    },
                    Settings.HeroClassToSnoPowers[HeroClass.None],
                    "NameEnglish"
                ),
                SimpleParameter<bool>.of(nameof(OverrideSelectedWithSno), x => OverrideSelectedWithSno = x),
                SimpleParameter<int>.of(nameof(Sno), x => Sno = (uint)x)
            };
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            return hud.Game.Me.Powers.BuffIsActive(OverrideSelectedWithSno ? Sno : SelectedSno);
        }
    }
}