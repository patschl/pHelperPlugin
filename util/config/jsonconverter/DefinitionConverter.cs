namespace Turbo.Plugins.Patrick.util.config.jsonconverter
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using plugins.patrick.skills.definitions;

    public class DefinitionConverter : JsonConverter<AbstractDefinition>
    {
        public override void WriteJson(JsonWriter writer, AbstractDefinition value, JsonSerializer serializer)
        {
            var token = JObject.FromObject(value);
            token.AddFirst(new JProperty("type", value.GetType().ToString()));
            token.WriteTo(writer);
        }

        public override AbstractDefinition ReadJson(
            JsonReader reader,
            Type objectType,
            AbstractDefinition existingValue,
            bool hasExistingValue,
            JsonSerializer serializer
        )
        {
            var definition = JObject.Load(reader);

            var definitionTypeName = (definition["type"] ?? throw new InvalidOperationException("Type missing from Definition!")).Value<string>();
            var definitionType = GetDefinitionType(definitionTypeName);

            var result = Activator.CreateInstance(definitionType);
            serializer.Populate(definition.CreateReader(), result);

            return result as AbstractDefinition;
        }

        private static Type GetDefinitionType(string typeName)
        {
            return AbstractDefinition.DefinitionTypes.First(type => type.ToString().Equals(typeName));
        }
    }
}