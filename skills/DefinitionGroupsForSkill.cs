namespace Turbo.plugins.patrick.skills
{
    using System.Collections.Generic;

    public class DefinitionGroupsForSkill
    {
        public bool active { get; set; }
        
        public string heroClassName { get; }
        
        public string skillName { get; }
        
        public string configProfileName { get; }

        public List<DefinitionGroup> definitionGroups { get; }

        public DefinitionGroupsForSkill()
        {
            active = true;
            definitionGroups = new List<DefinitionGroup>();
        }

        public DefinitionGroupsForSkill(string heroClassName, string skillName, string configProfileName)
        {
            active = true;
            definitionGroups = new List<DefinitionGroup>();
            this.heroClassName = heroClassName;
            this.skillName = skillName;
            this.configProfileName = configProfileName;
        }
    }
}
