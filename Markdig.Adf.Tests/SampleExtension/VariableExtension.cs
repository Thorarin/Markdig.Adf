using Markdig;
using Markdig.Renderers;

namespace Visp.ProblemManagement.AzureFunctions.Templating
{
    internal class VariableExtension : IMarkdownExtension
    {
        public void Setup(MarkdownPipelineBuilder pipeline)
        {
            pipeline.InlineParsers.AddIfNotAlready<VariableInlineParser>();
        }

        public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
        {
            var adfRenderer = renderer as AdfRenderer;
            var renderers = adfRenderer?.ObjectRenderers;

            if (renderers != null && !renderers.Contains<VariableRenderer>())
            {
                renderers.Add(new VariableRenderer());
            }
        }
    }
}
