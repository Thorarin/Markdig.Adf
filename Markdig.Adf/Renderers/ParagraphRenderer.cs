using Markdig.Adf.Nodes;
using Markdig.Renderers;
using Markdig.Renderers.Adf;
using Markdig.Syntax;

namespace Markdig.Adf.Renderers
{
    internal class ParagraphRenderer : AdfObjectRenderer<ParagraphBlock>
    {
        protected override void Write(AdfRenderer renderer, ParagraphBlock obj)
        {
            var paragraph = new ParagraphNode();

            renderer.Push(paragraph);
            renderer.WriteLeafInline(obj);
            renderer.Pop();
        }
    }
}
