namespace Turbo.plugins.patrick.skills.castactions.actions
{
    using patrick.util.thud;
    using Plugins;

    public class DefaultCastAction : AbstractCastAction
    {
        public override string name
        {
            get
            {
                return "DefaultCastAction";
            }
        }

        public override bool Invoke(IController hud, IPlayerSkill skill)
        {
            if (skill.IsOnCooldown)
                return false;

            var resourceCostType = skill.SnoPower.ResourceCostTypeByRune[skill.Rune == 255 ? 0 : skill.Rune];
            var currentResource = resourceCostType == PowerResourceCostType.primary
                ? hud.Game.Me.Stats.ResourceCurPri
                : hud.Game.Me.Stats.ResourceCurSec;

            if (currentResource < skill.GetResourceRequirement(skill.ResourceCost))
                return false;

            skill.Cast();
            return true;
        }
    }
}