using Xunit;

namespace MarkdownBook.Test
{
    public class ParserTests
    {
        [Fact]
        public void ParserShouldReadAllMarkdown()
        {
            var loader = new BookLoader("SupportedMarkdown.md");
            var book = loader.Load();
            
            Assert.Single(book.Chapters);
        }
    }
}