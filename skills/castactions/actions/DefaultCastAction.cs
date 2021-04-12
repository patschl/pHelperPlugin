namespace Turbo.plugins.patrick.skills.castactions.actions
{
    using Plugins;
    using util.thud;

    public class DefaultCastAction : AbstractCastAction
    {
        public override string name
        {
            get
            {
                return "DefaultCastAction";
            }
        }

        public override void Invoke(IController hud, IPlayerSkill skill)
        {
            if (skill.IsOnCooldown)
                return;

            var resourceCostType = skill.SnoPower.ResourceCostTypeByRune[skill.Rune];
            var currentResource = resourceCostType == PowerResourceCostType.primary
                ? hud.Game.Me.Stats.ResourceCurPri
                : hud.Game.Me.Stats.ResourceCurSec;

            if (currentResource < skill.GetResourceRequirement(skill.ResourceCost))
                return;

            skill.Cast();
        }
    }
}