using Markdig.Renderers;
using Markdig.Syntax;

namespace Markdig.Adf
{
    public static class MarkdownDocumentExtensions
    {
        public static AdfDocument ToAdfDocument(this MarkdownDocument document, MarkdownPipeline? pipeline = null)
        {
            pipeline ??= new MarkdownPipelineBuilder().Build();

            AdfDocument adfDocument = new AdfDocument();
            var renderer = new AdfRenderer(adfDocument);
            pipeline.Setup(renderer);

            renderer.Render(document);

            return adfDocument;
        }
    }
}
