using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Markdig.Adf;
using Markdig.Adf.Nodes;
using Markdig.Adf.Renderers;
using Markdig.Syntax;

// ReSharper disable once CheckNamespace
namespace Markdig.Renderers
{
    public class AdfRenderer : RendererBase
    {
        private readonly Stack<BlockNode> _stack = new Stack<BlockNode>();

        public AdfDocument Document { get; }

        public AdfRenderer(AdfDocument document)
        {
            Document = document;

            _stack.Push(document);

            ObjectRenderers.Add(new HeadingRenderer());
            ObjectRenderers.Add(new ParagraphRenderer());
            ObjectRenderers.Add(new TextRenderer());
            ObjectRenderers.Add(new LineBreakRenderer());
        }

        public override object Render([NotNull] MarkdownObject markdownObject)
        {
            Write(markdownObject);

            return Document;
        }

        public void Push(BlockNode block)
        {
            _stack.Push(block);
        }

        public void Pop()
        {
            var popped = _stack.Pop();
            _stack.Peek().AddChild(popped);
        }

        private static void AddInline([NotNull] IBlockNode parent, [NotNull] INode inline)
        {
            parent.AddChild(inline);
        }

        public void WriteBlock([NotNull] IBlockNode blockNode)
        {
            _stack.Peek().AddChild(blockNode);
        }

        public void WriteInline([NotNull] IInlineNode inline)
        {
            AddInline(_stack.Peek(), inline);
        }

        public void WriteLeafInline([NotNull] LeafBlock leafBlock)
        {
            if (leafBlock == null) throw new ArgumentNullException(nameof(leafBlock));
            var inline = (Syntax.Inlines.Inline)leafBlock.Inline;
            while (inline != null)
            {
                Write(inline);
                inline = inline.NextSibling;
            }
        }
    }
}
