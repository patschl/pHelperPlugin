namespace Turbo.plugins.patrick.skills
{
    using System.Collections.Generic;
    using castactions;
    using castactions.actions;
    using definitions;
    using Newtonsoft.Json;
    using Plugins;
    using Plugins.Patrick.util.config.jsonconverter;

    public class DefinitionGroup
    {
        public bool active { get; set; }
        
        public string name { get; }
        
        public uint sno { get; }
        
        [JsonConverter(typeof(CastActionConverter))]
        public AbstractCastAction castAction { get; set; }
        
        [JsonProperty(ItemConverterType = typeof(DefinitionConverter))]
        public List<AbstractDefinition> definitions { get; }

        public DefinitionGroup(string name, uint sno)
        {
            active = true;
            this.name = name;
            this.sno = sno;
            definitions = new List<AbstractDefinition>();
            castAction = new DefaultCastAction();
        }

        public bool Applicable(IController hud, IPlayerSkill skill)
        {
            return active && definitions.TrueForAll(definition => definition.Handle(hud, skill));
        }

        public bool Invoke(IController hud, IPlayerSkill skill)
        {
            return castAction.Invoke(hud, skill);
        }
    }
}