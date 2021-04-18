namespace Turbo.plugins.patrick.skills.definitions.player
{
    using System.Collections.Generic;
    using System.Drawing;
    using parameters;
    using parameters.types;
    using Plugins;
    using Plugins.Patrick.forms;

    public class IsSkillBuffActive : AbstractDefinition
    {
        public string BuffName { get; set; }
        
        public uint SelectedSno { get; set; }
        
        public bool OverrideSelected { get; set; }
        
        public uint Sno { get; set; }
        
        public int IconIndex { get; set; }

        public override DefinitionType category => DefinitionType.Player;

        public override string attributes
        {
            get
            {
                var assembledBuffName = OverrideSelected ? $"Sno: {Sno}, " : $"SkillBuff: {BuffName}, ";
                return $"[ {assembledBuffName}IconIndex: {IconIndex} ]";
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
                        if (!(input is ISnoPower power))
                            return;
                        BuffName = power.NameEnglish;
                        SelectedSno = power.Sno;
                    },
                    Settings.HeroClassToSnoPowers[HeroClass.None],
                    "NameEnglish"
                ),
                SimpleParameter<int>.of(nameof(IconIndex), x => IconIndex = x),
                SimpleParameter<bool>.of(nameof(OverrideSelected), x => OverrideSelected = x),
                SimpleParameter<int>.of(nameof(Sno), x => Sno = (uint)x)
            };
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            return hud.Game.Me.Powers.BuffIsActive(OverrideSelected ? Sno : SelectedSno, IconIndex);
        }
    }
}