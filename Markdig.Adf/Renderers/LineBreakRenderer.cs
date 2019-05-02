using Markdig.Adf.Nodes;
using Markdig.Renderers;
using Markdig.Renderers.Adf;
using Markdig.Syntax.Inlines;

namespace Markdig.Adf.Renderers
{
    public class LineBreakRenderer : AdfObjectRenderer<LineBreakInline>
    {
        protected override void Write(AdfRenderer renderer, LineBreakInline obj)
        {
            renderer.WriteInline(new HardBreakNode());
        }
    }
}
