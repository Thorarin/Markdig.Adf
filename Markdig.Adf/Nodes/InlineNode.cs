namespace Markdig.Adf.Nodes
{
    public abstract class InlineNode : NodeBase, IInlineNode
    {
        protected InlineNode(string type) : base(type)
        {
        }
    }
}
