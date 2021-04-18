namespace Turbo.plugins.patrick.skills.definitions.skill
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using Newtonsoft.Json;
    using parameters;
    using parameters.types;
    using Plugins;

    public class ForceCastInterval : AbstractDefinition
    {
        public int IntervalInMs { get; set; }
        
        [JsonIgnore]
        private readonly Stopwatch watch = Stopwatch.StartNew();

        public override DefinitionType category => DefinitionType.Skill;

        public override string attributes => $"[ Interval: {IntervalInMs}ms ]";

        public override List<AbstractParameter> GetParameters(IController hud)
        {
            return new List<AbstractParameter> {SimpleParameter<int>.of(nameof(IntervalInMs), x => IntervalInMs = x)};
        }

        protected override bool Applicable(IController hud, IPlayerSkill skill)
        {
            if (watch.ElapsedMilliseconds <= IntervalInMs) 
                return false;
            
            watch.Restart();
            return true;
        }
    }
}