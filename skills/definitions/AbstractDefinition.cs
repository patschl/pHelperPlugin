namespace Turbo.plugins.patrick.skills.definitions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using parameters;
    using Plugins;
    using Plugins.Patrick.util;

    public abstract class AbstractDefinition
    {

        public static readonly List<Type> DefinitionTypes = Misc.GetAllSubTypesFromType(typeof(AbstractDefinition));

        public static readonly Dictionary<DefinitionType, List<Type>> CategoryToType = DefinitionTypes
            .Select(type => (AbstractDefinition)Activator.CreateInstance(type))
            .GroupBy(def => def.category, def => def.GetType())
            .ToDictionary(def => def.Key, def => def.ToList());

        [JsonIgnore]
        public DefinitionGroup definitionGroup { get; set; }
        
        public bool active { get; set; }

        public bool inverted { get; set; }

        protected AbstractDefinition()
        {
            active = true;
            inverted = false;
        }

        protected AbstractDefinition(bool inverted)
        {
            active = true;
            this.inverted = inverted;
        }

        public void SetParentDefinitionGroup(DefinitionGroup definitionGroup)
        {
            this.definitionGroup = definitionGroup;
        }

        public string name
        {
            get
            {
                return $"{category} - " + GetType().Name;
            }
        }

        [JsonIgnore]
        public virtual string tooltip
        {
            get
            {
                return "No tooltip available for this definition type!";
            }
        }

        [JsonIgnore] 
        public abstract DefinitionType category { get; }

        [JsonIgnore]
        public abstract string attributes { get; }

        public abstract List<AbstractParameter> GetParameters(IController hud);

        public bool Handle(IController hud, IPlayerSkill skill)
        {
            var result = Applicable(hud, skill);

            return inverted ? !result : result;
        }

        protected abstract bool Applicable(IController hud, IPlayerSkill skill);
    }
}