namespace Turbo.plugins.patrick.skills.definitions.player {

	using System;
	using System.Collections.Generic;
	using parameters;
	using parameters.types;
	using Plugins;

	public class MinimumAttackSpeed : AbstractDefinition {
		public float minimumAttackSpeed { get; set; }

		public override DefinitionType category => DefinitionType.Player;

		public override string attributes => $"[ minimumAttackSpeed: {minimumAttackSpeed} ]";

		public override List<AbstractParameter> GetParameters(IController hud) {
			return new List<AbstractParameter> {
				SimpleParameter<float>.of(nameof(minimumAttackSpeed), x => minimumAttackSpeed = x)
			};
		}

		protected override bool Applicable(IController hud, IPlayerSkill skill) {
			var me = hud.Game.Me;
			switch(me.HeroClassDefinition.HeroClass) {
				case HeroClass.Wizard :
				case HeroClass.WitchDoctor :
				case HeroClass.Crusader :
				case HeroClass.Necromancer :
					return me.Offense.AttackSpeedMainHand >= minimumAttackSpeed;

				case HeroClass.Barbarian :
				case HeroClass.DemonHunter :
					if (me.Offense.AttackSpeedOffHand > 0)
						return (me.Offense.AttackSpeedMainHand >= minimumAttackSpeed && me.Offense.AttackSpeedOffHand >= minimumAttackSpeed);

					return me.Offense.AttackSpeedMainHand >= minimumAttackSpeed;
			}

			var speedMultiplier = me.Powers.BuffIsActive(246562, 1) ? 2f : 1f; // FlyingDragon for Monk

			if (me.Offense.AttackSpeedOffHand > 0)
				return (me.Offense.AttackSpeedMainHand * speedMultiplier >= minimumAttackSpeed &&
						me.Offense.AttackSpeedOffHand * speedMultiplier >= minimumAttackSpeed);

			return me.Offense.AttackSpeedMainHand * speedMultiplier >= minimumAttackSpeed;
		}
	}
}