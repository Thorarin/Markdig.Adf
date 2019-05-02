using Markdig.Parsers;
using Markdig.Renderers;
using Markdig.Syntax;
using Newtonsoft.Json;
using Visp.ProblemManagement.AzureFunctions.Templating;
using Xunit;

namespace Markdig.Adf.Tests
{
    public class UnitTest1
    {
        public MarkdownDocument TestDocument { get; }

        public UnitTest1()
        {
            TestDocument = Markdown.Parse("# Hallo\r\n## Test\r\nBla");
        }

        [Fact]
        public void Test1()
        {
            var doc = TestDocument.ToAdfDocument().ToJsonString();
        }

        [Fact]
        public void Test2()
        {
            var dto = new JsonDto
            {
                StringProperty = "Bla",
                Document = TestDocument.ToAdfDocument()
            };

            var json = JsonConvert.SerializeObject(dto);
        }

        [Fact]
        public void Test3()
        {
            var pipeline = new MarkdownPipelineBuilder()
                .Use<VariableExtension>()
                .Build();

            var doc = MarkdownParser.Parse("# Hallo\r\n## Test\r\n$(Test)\r\nTest", pipeline);

            var adf = new AdfDocument();
            var renderer = new AdfRenderer(adf);
            pipeline.Setup(renderer);

            renderer.Render(doc);
        }
    }
}