using System.Linq;
using FluentAssertions;
using Markdig.Adf.Nodes;
using Markdig.Syntax;
using Xunit;

namespace Markdig.Adf.Tests
{
    public class MarkdownDocumentExtensionsTests
    {
        public MarkdownDocument TestDocument { get; }

        public MarkdownDocumentExtensionsTests()
        {
            TestDocument = Markdown.Parse("# Heading One\r\n## Heading Two\r\nParagraph One");
        }

        [Fact]
        public void ToAdfDocument_ShouldContainTwoHeadings()
        {
            var doc = TestDocument.ToAdfDocument();

            doc.Content.OfType<HeadingNode>().Should().HaveCount(2);
        }

        [Fact]
        public void ToAdfDocument_ShouldContainOneParagraph()
        {
            var doc = TestDocument.ToAdfDocument();

            doc.Content.OfType<ParagraphNode>().Should().HaveCount(1);

            doc.Content.OfType<ParagraphNode>().Single().Content.Should().HaveCount(1);
            doc.Content.OfType<ParagraphNode>().Single().Content.Should().HaveCount(1);
        }

        [Fact]
        public void ToAdfDocument_ShouldHaveOneTextNodeInParagraph()
        {
            var doc = TestDocument.ToAdfDocument();

            var paragraph = doc.Content.OfType<ParagraphNode>().SingleOrDefault();

            Assert.NotNull(paragraph);
            paragraph.Content.Should().HaveCount(1);
            paragraph.Content[0].Should().BeOfType<TextNode>()
                .Which.Text.Should().Be("Paragraph One");
        }
    }
}