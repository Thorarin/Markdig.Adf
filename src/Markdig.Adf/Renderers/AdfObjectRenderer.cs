using Markdig.Renderers;
using Markdig.Syntax;

namespace Markdig.Adf.Renderers
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
