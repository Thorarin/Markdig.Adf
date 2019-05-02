using Markdig.Syntax;

namespace Markdig.Renderers.Adf
{
    /// <summary>
    /// A base class for ADF rendering Markdown objects.
    /// </summary>
    /// <typeparam name="TObject">The type of the object.</typeparam>
    /// <seealso cref="IMarkdownObjectRenderer" />
    public abstract class AdfObjectRenderer<TObject> : MarkdownObjectRenderer<AdfRenderer, TObject> where TObject : MarkdownObject
    {
    }
}
