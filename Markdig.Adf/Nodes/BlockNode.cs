using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Markdig.Adf.Nodes
{
    public abstract class BlockNode : NodeBase, IBlockNode
    {
        protected BlockNode(string type) : base(type)
        {
        }

        public void AddChild(INode child)
        {
            if (Content == null)
            {
                Content = new List<INode>();
            }

            Content.Add(child);
        }

        [JsonProperty(Order = 100)]
        [ItemNotNull]
        public IList<INode>? Content { get; private set; }
    }
}
