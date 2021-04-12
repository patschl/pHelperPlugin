namespace Turbo.Plugins.Patrick.hotkeys
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Default;
    using Newtonsoft.Json;
    using plugins.patrick.hotkeys.actions;
    using plugins.patrick.util.executors;
    using util;
    using util.config.jsonconverter;

    public class HotkeyContainer
    {
        [JsonProperty(ItemConverterType = typeof(HotkeyConverter))]
        public List<AbstractHotkeyAction> hotkeyActions { get; }

        [JsonIgnore] private readonly ThreadedExecutor executor = new ThreadedExecutor();

        public HotkeyContainer()
        {
            hotkeyActions = new List<AbstractHotkeyAction>();
        }

        public HotkeyContainer(List<AbstractHotkeyAction> hotkeyActions)
        {
            this.hotkeyActions = hotkeyActions;
        }

        public void InitializeIKeyEventsAndSort(IInputController inputController)
        {
            hotkeyActions
                .Where(hotkey => !(hotkey.keyEvent is null))
                .ForEach(hotkey => hotkey.iKeyEvent = hotkey.keyEvent.toIKeyEvent(inputController));

            hotkeyActions.Sort((left, right) => string.Compare(left.action, right.action, StringComparison.Ordinal));
        }

        public void InvokeIfExists(IKeyEvent keyEvent, IController hud)
        {
            var hotkey = hotkeyActions
                .Where(hk => !(hk.iKeyEvent is null) &&
                             hk.active &&
                             hk.iKeyEvent.Matches(keyEvent))
                .FirstOrDefault(hk => hk.PreconditionSatisfied(hud));

            if (hotkey != null)
                executor.Execute(() => hotkey.Invoke(hud), hotkey.GetType().ToString(), hotkey.minimumExecutionDelta);
        }
    }
}