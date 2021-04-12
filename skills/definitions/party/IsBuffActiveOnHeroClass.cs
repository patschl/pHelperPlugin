namespace Turbo.plugins.patrick.skills.definitions.party
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using parameters;
    using parameters.types;
    using Plugins;
    using Plugins.Patrick.forms;

    public class IsBuffActiveOnHeroClass : AbstractDefinition
    {
        public HeroClass heroClass { get; set; }

        public uint SelectedSno { get; set; }
        
        public string buffName { get; set; }
        
        public bool OverrideSelectedWithSno { get; set; }
        
        public uint Sno { get; set; }

        public override DefinitionType category
        {
            get
            {
                return DefinitionType.Party;
            }
        }

        public override string attributes
        {
            get
            {
                return $"[ HeroClass: {heroClass}, Buff: {buffName} ]";
            }
        }

        public override List<AbstractParameter> GetParameters(IController hud)
        {
            return new List<AbstractParameter>
            {
                ContextParameter.of(
                    nameof(heroClass),
                    input => heroClass = (HeroClass)input,
                    Enum.GetValues(typeof(HeroClass)).Cast<Enum>()
                ),
                ContextParameter.of(
                    nameof(buffName),
                    input =>
                    {
                        if (!(input is KeyValuePair<string, ISnoPower> pair))
                            return;
                        buffName = pair.Key;
                        SelectedSno = pair.Value.Sno;
                    },
                    Settings.NameToSnoPower,
                    "Key"
                ),
                SimpleParameter<bool>.of(nameof(OverrideSelectedWithSno), x => OverrideSelectedWithSno = x),
                SimpleParameter<int>.of(nameof(Sno), x => Sno = (uint)x)
            };
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            return hud.Game.Players.Any(player => !player.IsMe && 
                                                  player.HeroClassDefinition.HeroClass == heroClass && 
                                                  player.Powers.BuffIsActive(OverrideSelectedWithSno ? Sno : SelectedSno));
        }
    }
}