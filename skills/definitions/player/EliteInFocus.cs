namespace Turbo.plugins.patrick.skills.definitions.player
{
    using System.Collections.Generic;
    using System.Linq;
    using parameters;
    using parameters.types;
    using Plugins;

    public class EliteInFocus : AbstractDefinition
    {
        public bool IncludeShocktower { get; set; }

        public override DefinitionType category => DefinitionType.Player;

        public override string attributes => $"[ Include Shocktower: {IncludeShocktower} ]";

        public override List<AbstractParameter> GetParameters(IController hud)
        {
            return new List<AbstractParameter> {SimpleParameter<bool>.of(nameof(IncludeShocktower), x => IncludeShocktower = x)};
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            var selectedMonster = hud.Game.SelectedMonster2 ?? hud.Game.SelectedMonster1;
            if (selectedMonster is null)
                return false;

            var eliteTargeted = selectedMonster.Rarity == ActorRarity.Champion || selectedMonster.Rarity == ActorRarity.Rare ||
                                selectedMonster.Rarity == ActorRarity.Unique || selectedMonster.Rarity == ActorRarity.Boss;

            eliteTargeted |= IncludeShocktower && selectedMonster.SnoActor.Sno == ActorSnoEnum._x1_pand_ext_ordnance_tower_shock_a;
            
            return eliteTargeted;
        }
    }
}