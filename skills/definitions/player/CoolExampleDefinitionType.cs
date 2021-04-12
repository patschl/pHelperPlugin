namespace Turbo.plugins.patrick.skills.definitions.player
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using parameters;
    using parameters.types;
    using Plugins;

    public class CoolExampleDefinitionType : AbstractDefinition
    {
        public string Rune { get; set; }
        
        public string MateWithName { get; set; }

        public bool BossIsSpawned { get; set; }

        public int NumberOfDhsInGame { get; set; }

        public SpecialArea SpecialArea { get; set; }
        
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
                return $"[ Rune: {Rune}, BossIsSpawned: {BossIsSpawned}, Number of DHs: {NumberOfDhsInGame}, Area: {SpecialArea} ]";
            }
        }

        public override List<AbstractParameter> GetParameters(IController hud)
        {
            return new List<AbstractParameter>
            {
                ContextParameter.of(
                    nameof(Rune),
                    x => Rune = (string)x,
                    hud.Sno.GetSnoPower(definitionGroup.sno)?.RuneNamesEnglish
                ),
                SimpleParameter<string>.of(nameof(MateWithName), x => MateWithName = x),
                SimpleParameter<bool>.of(nameof(BossIsSpawned), x => BossIsSpawned = x),
                SimpleParameter<int>.of(nameof(NumberOfDhsInGame), input => NumberOfDhsInGame = input),
                ContextParameter.of(
                    nameof(SpecialArea),
                    input => SpecialArea = (SpecialArea)input,
                    Enum.GetValues(typeof(SpecialArea)).Cast<Enum>()
                )
            };
        }

        public override string tooltip
        {
            get
            {
                return "Exmaple definition type to show off some settings!";
            }
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            var correctRune = skill.RuneNameEnglish.Equals(Rune);
            var mateWithNameInGame = hud.Game.Players.Any(p => p.HeroName.Equals(MateWithName));
            var bossIsSpawnedCorrect = hud.Game.Monsters.Any(monster => monster.Rarity == ActorRarity.Boss) == BossIsSpawned;
            var numberOfDhsInGameCorrect = hud.Game.Players
                .Where(player => !player.IsMe)
                .Count(player => player.HeroClassDefinition.HeroClass == HeroClass.DemonHunter) == NumberOfDhsInGame;
            var correctSpecialArea = hud.Game.SpecialArea == SpecialArea;


            return correctRune && bossIsSpawnedCorrect && numberOfDhsInGameCorrect && correctSpecialArea && mateWithNameInGame;
        }
    }
}