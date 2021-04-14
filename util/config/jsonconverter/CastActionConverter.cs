namespace Turbo.Plugins.Patrick.util.config.jsonconverter
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using plugins.patrick.skills.castactions;

    public class CastActionConverter : JsonConverter<AbstractCastAction>
    {
        public override void WriteJson(JsonWriter writer, AbstractCastAction value, JsonSerializer serializer)
        {
            var token = JObject.FromObject(value);
            token.AddFirst(new JProperty("type", value.GetType().ToString()));
            token.WriteTo(writer);
        }

        public override AbstractCastAction ReadJson(JsonReader reader, Type objectType, AbstractCastAction existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            var castAction = JObject.Load(reader);

            var typeName = (castAction["type"] ?? throw new InvalidOperationException("Type missing from CastAction!")).Value<string>();
            var type = GetCastActionType(typeName);

            var result = Activator.CreateInstance(type);
            serializer.Populate(castAction.CreateReader(), result);

            return result as AbstractCastAction;
        }

        private static Type GetCastActionType(string typeName)
        {
            return AbstractCastAction.CastActionTypes.First(type => type.ToString().Equals(typeName));
        }
    }
}