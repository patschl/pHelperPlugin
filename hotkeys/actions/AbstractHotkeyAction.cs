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
        public string action
        {
            get
            {
                return $"{type} - " + GetType().Name;
            }
        }

        [JsonIgnore] public string attributes { get { return GetAttributes(); } }

        [JsonIgnore] public string hotkey { get { return keyEvent == null ? "None" : keyEvent.ToString(); } }

        [Browsable(false)] public HotkeyPopup.MyKeyEvent keyEvent { get; set; }

        [JsonIgnore] 
        [Browsable(false)]
        public virtual string tooltip
        {
            get
            {
                return "No tooltip available for this hotkey!";
            }
        }
        
        [JsonIgnore] 
        [Browsable(false)]
        public virtual long minimumExecutionDelta
        {
            get
            {
                return 1000;
            }
        }


        [JsonIgnore] [Browsable(false)] public IKeyEvent iKeyEvent { get; set; }
        
        [JsonIgnore] [Browsable(false)] public abstract HotkeyType type { get; }

        protected abstract string GetAttributes();

        public abstract List<AbstractParameter> GetParameters();

        public abstract bool PreconditionSatisfied(IController hud);

        public void Invoke(IController hud)
        {
            try
            {
                InvokeInternal(hud);
            }
            catch (Exception e)
            {
                hud.Debug(e.ToString());
            }
        }

        protected abstract void InvokeInternal(IController hud);

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