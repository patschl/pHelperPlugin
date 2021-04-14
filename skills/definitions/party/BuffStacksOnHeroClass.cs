namespace Turbo.plugins.patrick.skills.definitions.party
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using parameters;
    using parameters.types;
    using Plugins;
    using Plugins.Patrick.forms;
    using util;

    public class BuffStacksOnHeroClass : AbstractDefinition
    {
        public HeroClass Class { get; set; }
        
        public string BuffName { get; set; }
        
        public int Range { get; set; }

        public int Stacks { get; set; }

        public string Operator { get; set; }

        public uint SelectedSno { get; set; }

        public bool OverrideSelected { get; set; }

        public uint Sno { get; set; }

        public int IconIndex { get; set; }

        public override DefinitionType category => DefinitionType.Party;

        public override string attributes
        {
            get
            {
                var assembledHeroName = Class == HeroClass.None ? "" : $"Hero: {Class}, ";
                var assembledBuffName = OverrideSelected ? $"Sno: {Sno}, " : $"Buff: {BuffName}, ";
                var assembledRange = Range == 0 ? "" : $"Range: {Range}, ";
                return $"[ {assembledHeroName}{assembledBuffName}{assembledRange}Stacks {Operator} {Stacks}, IconIndex: {IconIndex} ]";
            }
        }

        public override List<AbstractParameter> GetParameters(IController hud)
        {
            return new List<AbstractParameter>
            {
                ContextParameter.of(
                    nameof(Class),
                    input => Class = (HeroClass)input,
                    Enum.GetValues(typeof(HeroClass)).Cast<Enum>()
                ),
                SimpleParameter<int>.of(nameof(Range), x => Range = x),
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
                SimpleParameter<int>.of(nameof(Stacks), x => Stacks = x),
                SimpleParameter<int>.of(nameof(IconIndex), x => IconIndex = x),
                SimpleParameter<bool>.of(nameof(OverrideSelected), x => OverrideSelected = x),
                SimpleParameter<int>.of(nameof(Sno), x => Sno = (uint)x),
            };
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            var playerWithBuff = hud.Game.Players.FirstOrDefault(player => !player.IsMe &&
                                                                           (Class == HeroClass.None || player.HeroClassDefinition.HeroClass == Class) &&
                                                                           (Range == 0 || player.CentralXyDistanceToMe <= Range) &&
                                                                           player.Powers.GetBuff(OverrideSelected ? Sno : SelectedSno) != null);

            if (!(playerWithBuff?.Powers?.GetBuff(OverrideSelected ? Sno : SelectedSno) is IBuff buff))
                return false;

            return CompareWithOperator.Compare(buff.IconCounts[IconIndex], Stacks, Operator);
        }
    }
}