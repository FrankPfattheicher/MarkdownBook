using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Toolkit.Parsers.Markdown;
using Microsoft.Toolkit.Parsers.Markdown.Blocks;
using Microsoft.Toolkit.Parsers.Markdown.Inlines;

namespace MarkdownToPdf
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Markdown To PDF");

            //var initialDocument = @"C:\ICT Baden\Informant\docs\manual\Informant.md";
            var initialDocument = @"/home/frank/ICT Baden/MarkdownToPdf/README.md";
            
            var document = new MarkdownDocument();
            var documentPath = Path.GetDirectoryName(initialDocument);

            var documents = new List<string>
            {
                Path.GetFileName(initialDocument)
            };
            for (var documentIndex = 0; documentIndex < documents.Count; documentIndex++)
            {
                var documentFile = Path.Combine(documentPath, documents[documentIndex]);
                if (!File.Exists(documentFile))
                {
                    Console.WriteLine("Could not find " + documentFile);
                    continue;
                }
                Console.WriteLine("Processing " + documentFile);
                var markdownText = File.ReadAllText(documentFile);
                document.Parse(markdownText);
                
                foreach (var block in document.Blocks)
                {
                    if (block is ParagraphBlock paragraph)
                    {
                        foreach (var inline in paragraph.Inlines)
                        {
                            if (inline is MarkdownLinkInline mdLink)
                            {
                                var url = mdLink.Url;
                                if (url == null)
                                {
                                    Console.WriteLine($"{documents[documentIndex]}: Link without URL {mdLink.ReferenceId}");
                                    continue;
                                }
                                if (!documents.Contains(url))
                                {
                                    documents.Add(url);
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("done.");
        }
    }
}