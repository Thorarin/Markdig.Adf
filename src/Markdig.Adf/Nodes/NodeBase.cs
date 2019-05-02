using Newtonsoft.Json;

namespace Markdig.Adf.Nodes
{
    public abstract class NodeBase
    {
        protected NodeBase(string type)
        {
            Type = type;
        }

        [JsonProperty(Order = -2)]
        public string Type { get; }
    }
}
