using System;
using System.IO;

namespace MarkdownBook
{
    internal static class Program
    {
        // ReSharper disable once UnusedParameter.Local
        private static void Main(string[] args)
        {
            Console.WriteLine("Markdown To PDF");

            const string initialDocument = @"C:\ICT Baden\Informant\docs\manual\Informant.md";
            //const string initialDocument = @"/home/frank/ICT Baden/MarkdownBook/README.md";

            var loader = new BookLoader(initialDocument);
            var book = loader.Load();
            
            Console.WriteLine($"Book '{book.Name}' loaded with {book.Chapters.Count} chapters.");

            var renderer = new HtmlRenderer(Path.GetDirectoryName(initialDocument));
            var html = renderer.RenderBook(book);

            var htmlFile = $"{book.Name}.html";
            File.WriteAllText(htmlFile, html.ToString());
            
            Console.WriteLine("done.");
        }
    }
}