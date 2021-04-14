namespace Turbo.plugins.patrick.skills.definitions.player
{
    using System.Collections.Generic;
    using parameters;
    using parameters.types;
    using Plugins;
    using Plugins.Patrick.forms;

    public class IsBuffActive : AbstractDefinition
    {
        public string BuffName { get; set; }

        public uint SelectedSno { get; set; }
        
        public int IconIndex { get; set; }

        public bool OverrideSelected { get; set; }
        
        public uint Sno { get; set; }
        
        public override DefinitionType category => DefinitionType.Player;

        public override string attributes
        {
            get
            {
                var assembledOverride = OverrideSelected ? $"Sno: {Sno}, " : $"Buff: {BuffName}, ";
                return $"[ {assembledOverride}IconIndex: {IconIndex} ]";
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