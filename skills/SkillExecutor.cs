namespace Turbo.plugins.patrick.skills
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Plugins;
    using Plugins.Patrick.forms;

    public class SkillExecutor
    {
        private readonly Dictionary<uint, long> lastSkillExectuion = new Dictionary<uint, long>();

        private readonly Settings settings;

        private const long MINIMUM_CAST_DELTA = 500;

        public SkillExecutor(Settings settings)
        {
            this.settings = settings;
        }

        public void Cast(IPlayerSkill skill)
        {
            if (!settings.SnoToDefinitionGroups.TryGetValue(skill.SnoPower.Sno, out var definitionGroupsForSkill))
                return;

            if (!AllowedToCast(skill))
                return;
                
            var applicableGroup =
                definitionGroupsForSkill.definitionGroups.FirstOrDefault(definitionGroup => definitionGroup.Applicable(settings.Hud, skill));
            applicableGroup?.Invoke(settings.Hud, skill);
        }

        private bool AllowedToCast(IPlayerSkill skill)
        {
            var sno = skill.SnoPower.Sno;
            var now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            
            if (!lastSkillExectuion.ContainsKey(sno))
            {
                lastSkillExectuion.Add(sno, now);
                return true;
            }
            
            var lastExecutionTime = lastSkillExectuion[sno];
            if (now - lastExecutionTime < MINIMUM_CAST_DELTA)
                return false;

            lastSkillExectuion[sno] = now;
            return true;
        }
    }
}