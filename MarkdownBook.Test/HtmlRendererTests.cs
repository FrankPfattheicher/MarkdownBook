using System;
using System.IO;
using Xunit;

namespace MarkdownBook.Test
{
    public class HtmlRendererTests
    {
        [Fact]
        public void RendererShouldSupportAllMarkdownTypes()
        {
            var loader = new BookLoader("SupportedMarkdown.md");
            var book = loader.Load();

            var renderer = new HtmlRenderer(".");
            var html = renderer.RenderBook(book);
            
            File.WriteAllText("SupportedMarkdown.html", html.ToString());
            
            Assert.NotNull(html);
        }

    }
}