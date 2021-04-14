namespace Turbo.plugins.patrick.hotkeys.actions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using forms.hotkeys;
    using hotkeys;
    using Newtonsoft.Json;
    using parameters;
    using Plugins;
    using Plugins.Patrick.util;

    public abstract class AbstractHotkeyAction
    {
        public static readonly List<Type> HotkeyTypes = Misc.GetAllSubTypesFromType(typeof(AbstractHotkeyAction));

        public bool active { get; set; }

        [JsonIgnore]
        public string action => $"{type} - " + GetType().Name;

        [JsonIgnore] public string attributes => GetAttributes();

        [JsonIgnore] public string hotkey => keyEvent == null ? "None" : keyEvent.ToString();

        [Browsable(false)] public HotkeyPopup.MyKeyEvent keyEvent { get; set; }

        [JsonIgnore] 
        [Browsable(false)]
        public virtual string tooltip => "No tooltip available for this hotkey!";
            
        
        [JsonIgnore] 
        [Browsable(false)]
        public virtual long minimumExecutionDelta => 1000;


        [JsonIgnore] [Browsable(false)] public IKeyEvent iKeyEvent { get; set; }
        
        [JsonIgnore] [Browsable(false)] public abstract HotkeyType type { get; }

        protected abstract string GetAttributes();

        public abstract List<AbstractParameter> GetParameters();

        public abstract bool PreconditionSatisfied(IController hud);

        public abstract void Invoke(IController hud);

        public void SetKeyEvent(HotkeyPopup.MyKeyEvent keyEvent, IKeyEvent iKeyEvent)
        {
            this.keyEvent = keyEvent;
            this.iKeyEvent = iKeyEvent;
        }

        public void RemoveKeybind()
        {
            keyEvent = null;
            iKeyEvent = null;
        }
    }
}