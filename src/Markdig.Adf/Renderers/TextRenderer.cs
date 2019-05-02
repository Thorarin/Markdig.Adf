using Markdig.Adf.Nodes;
using Markdig.Renderers;
using Markdig.Syntax.Inlines;

namespace Markdig.Adf.Renderers
{
    internal class TextRenderer : AdfObjectRenderer<LiteralInline>
    {
        protected override void Write(AdfRenderer renderer, LiteralInline obj)
        {
            renderer.WriteInline(new TextNode(obj.Content.ToString()));
        }
    }
}
