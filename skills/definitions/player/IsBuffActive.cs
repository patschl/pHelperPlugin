namespace Turbo.plugins.patrick.skills.definitions.player
{
    using System.Collections.Generic;
    using parameters;
    using parameters.types;
    using Plugins;
    using Plugins.Patrick.forms;

    public class IsBuffActive : AbstractDefinition
    {
        public uint buff { get; set; }

        public string buffName { get; set; }
        
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
                return $"[ buff: {buffName} ]";
            }
        }

        public override List<AbstractParameter> GetParameters(IController hud)
        {
            return new List<AbstractParameter>
            {
                ContextParameter.of(
                    nameof(buffName),
                    input =>
                    {
                        if (!(input is KeyValuePair<string, ISnoPower> pair))
                            return;
                        buffName = pair.Key;
                        buff = pair.Value.Sno;
                    },
                    Settings.NameToSnoPower,
                    "Key"
                )
            };
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            return hud.Game.Me.Powers.BuffIsActive(buff);
        }
    }
}