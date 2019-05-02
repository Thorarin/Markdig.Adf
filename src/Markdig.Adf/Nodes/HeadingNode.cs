using Newtonsoft.Json;

namespace Markdig.Adf.Nodes
{
    public class HeadingNode : BlockNode
    {
        public HeadingNode(int level) : base("heading")
        {
            Attrs = new Attributes(level);
        }

        [JsonProperty]
        public Attributes Attrs { get; }

        public class Attributes
        {
            public Attributes(int level)
            {
                Level = level;
            }

            public int Level { get; }
        }
    }
}
