namespace Turbo.plugins.patrick.skills.definitions.player
{
    using System.Collections.Generic;
    using parameters;
    using parameters.types;
    using Plugins;
    using Plugins.Patrick.forms;
    using util;

    public class BuffTimeLeft : AbstractDefinition
    {
        public string BuffName { get; set; }

        public int TimeLeftInMs { get; set; }

        public string Operator { get; set; }

        public uint SelectedSno { get; set; }

        public bool OverrideSelected { get; set; }

        public uint Sno { get; set; }

        public int IconIndex { get; set; }

        public override DefinitionType category => DefinitionType.Player;
        
        public override string attributes
        {
            get
            {
                var assembledBuffName = OverrideSelected ? $"Sno: {Sno}, " : $"Buff: {BuffName}, ";
                return $"[ {assembledBuffName}TimeLeft {Operator} {TimeLeftInMs}ms, IconIndex: {IconIndex} ]";
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
                    Settings.NameToSnoPower,
                    "Key"
                ),
                ContextParameter.of(
                    nameof(Operator),
                    x => Operator = (string)x,
                    CompareWithOperator.AllOperators
                ),
                SimpleParameter<int>.of(nameof(TimeLeftInMs), x => TimeLeftInMs = x),
                SimpleParameter<int>.of(nameof(IconIndex), x => IconIndex = x),
                SimpleParameter<bool>.of(nameof(OverrideSelected), x =>
                {
                    OverrideSelected = x;
                    if (OverrideSelected)
                        BuffName = "";
                }),
                SimpleParameter<int>.of(nameof(Sno), x => Sno = (uint)x),
            };
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            if (!(hud.Game.Me.Powers.GetBuff(OverrideSelected ? Sno : SelectedSno) is IBuff buff))
                return false;

            return CompareWithOperator.Compare((int) (buff.TimeLeftSeconds[IconIndex] * 1000L), TimeLeftInMs, Operator);
        }
    }
}