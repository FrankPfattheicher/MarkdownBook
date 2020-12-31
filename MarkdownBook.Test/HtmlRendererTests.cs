using System.IO;
using Xunit;

namespace MarkdownBook.Test
{
    public class HtmlRendererTests
    {
        private readonly string _html;
        
        public HtmlRendererTests()
        {
            var loader = new BookLoader("SupportedMarkdown.md");
            var book = loader.Load();

            var renderer = new HtmlRenderer(new RenderOptions());
            _html = renderer.RenderBook(book).ToString();
            
            File.WriteAllText("SupportedMarkdown.html", _html);
        }
        
        [Fact]
        public void RendererShouldGenerateHtml()
        {
            Assert.False(string.IsNullOrEmpty(_html));
        }
        
        [Fact]
        public void ShouldRenderUnderlineH1()
        {
            Assert.Contains("<h1>Header1a</h1>", _html);
        }
        [Fact]
        public void ShouldRenderUnderlineH2()
        {
            Assert.Contains("<h2>Header2a</h2>", _html);
        }

        [Theory]
        [InlineData("<h1> Header1b</h1>")]
        [InlineData("<h2> Header2b</h2>")]
        [InlineData("<h3> Header3b</h3>")]
        [InlineData("<h4> Header4b</h4>")]
        [InlineData("<h5> Header5b</h5>")]
        public void ShouldRenderHashHeaders(string expected)
        {
            Assert.Contains(expected, _html);
        }
        
        
    }
}