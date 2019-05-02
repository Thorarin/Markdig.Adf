using Markdig.Adf.Nodes;
using Markdig.Renderers;
using Markdig.Renderers.Adf;
using Markdig.Syntax;

namespace Markdig.Adf.Renderers
{
    internal class HeadingRenderer : AdfObjectRenderer<HeadingBlock>
    {
        protected override void Write(AdfRenderer renderer, HeadingBlock obj)
        {
            var heading = new HeadingNode(obj.Level);

            renderer.Push(heading);
            renderer.WriteLeafInline(obj);
            renderer.Pop();
        }
    }
}
