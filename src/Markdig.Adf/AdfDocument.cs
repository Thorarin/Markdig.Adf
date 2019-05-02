using Markdig.Adf.Nodes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Markdig.Adf
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class AdfDocument : BlockNode
    {
        private static readonly JsonSerializerSettings _serializerSettings;

        static AdfDocument()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public AdfDocument() : base("doc")
        {
        }

        public int Version => 1;

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, _serializerSettings);
        }
    }
}
