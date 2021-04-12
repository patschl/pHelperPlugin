namespace Turbo.Plugins.Patrick.util.config.jsonconverter
{
    using System;
    using System.Linq;
    using autoactions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using plugins.patrick.autoactions.actions;

    public class AutoActionConverter : JsonConverter<AbstractAutoAction>
    {
        public override void WriteJson(JsonWriter writer, AbstractAutoAction value, JsonSerializer serializer)
        {
            var token = JObject.FromObject(value);
            token.AddFirst(new JProperty("type", value.GetType().ToString()));
            token.WriteTo(writer);
        }

        public override AbstractAutoAction ReadJson(JsonReader reader, Type objectType, AbstractAutoAction existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var autoAction = JObject.Load(reader);
            autoAction.Remove("name");

            var autoActionTypeName = (autoAction["type"] ?? throw new InvalidOperationException("Type missing from AutoAction!")).Value<string>();
            var autoActionType = GetAutoActionType(autoActionTypeName);

            var result = Activator.CreateInstance(autoActionType);
            serializer.Populate(autoAction.CreateReader(), result);

            return result as AbstractAutoAction;
        }
        
        private static Type GetAutoActionType(string typeName)
        {
            return AbstractAutoAction.AutoActionTypes.First(type => type.ToString().Equals(typeName));
        }
    }
}