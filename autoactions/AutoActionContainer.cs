namespace Turbo.Plugins.Patrick.autoactions
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using plugins.patrick.autoactions.actions;
    using plugins.patrick.util.executors;
    using util.config.jsonconverter;

    public class AutoActionContainer
    {
        [JsonProperty(ItemConverterType = typeof(AutoActionConverter))]
        public List<AbstractAutoAction> autoActions;
        
        [JsonIgnore] private readonly ThreadedExecutor executor = new ThreadedExecutor();

        public AutoActionContainer()
        {
            autoActions = new List<AbstractAutoAction>();
        }

        public AutoActionContainer(List<AbstractAutoAction> autoActions)
        {
            this.autoActions = autoActions;
        }

        public void ExecuteAutoActions(IController hud)
        {
            autoActions.ForEach(action =>
            {
                if (!action.active || !action.Applicable(hud))
                    return;

                executor.Execute(() => action.Invoke(hud), action.GetType().ToString(), action.minimumExecutionDelta);
            });
        }
    }
}