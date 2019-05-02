using System.Collections.Generic;
using JetBrains.Annotations;

namespace Markdig.Adf.Nodes
{
    [PublicAPI]
    public interface IBlockNode : INode
    {
        IList<INode>? Content { get; }

        void AddChild(INode child);
    }
}
