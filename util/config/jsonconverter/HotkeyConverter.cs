namespace Turbo.Plugins.Patrick.util.config.jsonconverter
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using plugins.patrick.hotkeys.actions;

    public class HotkeyConverter: JsonConverter<AbstractHotkeyAction>
    {
        public override void WriteJson(JsonWriter writer, AbstractHotkeyAction value, JsonSerializer serializer)
        {
            var token = JObject.FromObject(value);
            token.AddFirst(new JProperty("type", value.GetType().ToString()));
            token.WriteTo(writer);
        }

        public override AbstractHotkeyAction ReadJson(JsonReader reader, Type objectType, AbstractHotkeyAction existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var hotkey = JObject.Load(reader);
            hotkey.Remove("name");

            var hotkeyTypeName = (hotkey["type"] ?? throw new InvalidOperationException("Type missing from Hotkey!")).Value<string>();
            var hotkeyType = GetHotkeyType(hotkeyTypeName);

            var result = Activator.CreateInstance(hotkeyType);
            serializer.Populate(hotkey.CreateReader(), result);

            return result as AbstractHotkeyAction;
        }
        
        
        private static Type GetHotkeyType(string typeName)
        {
            return AbstractHotkeyAction.HotkeyTypes.First(type => type.ToString().Equals(typeName));
        }
    }
}