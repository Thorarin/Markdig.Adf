using Newtonsoft.Json;

namespace Markdig.Adf.Nodes
{
    public class TextNode : InlineNode
    {
        public TextNode(string text) : base("text")
        {
            Text = text;
        }

        [JsonProperty]
        public string Text { get; }
    }
}
