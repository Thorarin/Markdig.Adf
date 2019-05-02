using Markdig.Adf.Nodes;
using Markdig.Renderers;
using Markdig.Renderers.Adf;

namespace Visp.ProblemManagement.AzureFunctions.Templating
{
    internal class VariableRenderer : AdfObjectRenderer<VariableInline>
    {
        protected override void Write(AdfRenderer renderer, VariableInline obj)
        {
            renderer.WriteInline(new TextNode("Blaat"));
        }
    }
}
