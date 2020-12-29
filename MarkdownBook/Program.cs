using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MarkdownBook
{
    internal static class Program
    {
        // ReSharper disable once UnusedParameter.Local
        private static void Main(string[] args)
        {
            Console.WriteLine("MarkdownBook");

            if (args.Length == 0)
            {
                Console.WriteLine($"Specify initial markdown document as parameter.");
                Environment.Exit(0);
            }
            var initialDocument = args[0];
            Console.WriteLine($"Using initial markdown document {initialDocument}.");

            if (!File.Exists(initialDocument))
            {
                Console.WriteLine($"Initial markdown document not found.");
                Environment.Exit(1);
            }
            
            var loader = new BookLoader(initialDocument);
            var book = loader.Load();
            
            Console.WriteLine($"Book '{book.Name}' loaded with {book.Chapters.Count} chapters.");

            var options = new RenderOptions
            {
                SourcePath = Path.GetDirectoryName(initialDocument),
                TargetPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                CopyAssets = args.Any(a => a == "-c"),
                MultipleFiles = args.Any(a => a == "-m")
            };
            
            var css = Path.ChangeExtension(initialDocument, "css");
            if (File.Exists(css))
            {
                options.CssFile = css;
            }
            
            var renderer = new HtmlRenderer(options);
            renderer.RenderBookToFile(book);
            
            Console.WriteLine("done.");
        }
    }
}