using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Toolkit.Parsers.Markdown;
using Microsoft.Toolkit.Parsers.Markdown.Blocks;
using Microsoft.Toolkit.Parsers.Markdown.Inlines;

namespace MarkdownBook
{
    [DebuggerDisplay("{" + nameof(Name) + "}")]
    public class Chapter
    {
        public string Name { get; private set; }
        private readonly string _fileName;
        private readonly MarkdownDocument _markdown;
        
        public Chapter(string fileName)
        {
            _fileName = fileName;
            Name = Path.GetFileNameWithoutExtension(fileName);
            
            var markdownText = File.ReadAllText(fileName);
            _markdown = new MarkdownDocument();
            _markdown.Parse(markdownText);
        }

        public List<MarkdownBlock> GetMarkdownBlocks() => _markdown.Blocks.ToList();
        
        public List<string> GetReferencedDocuments()
        {
            var referencedDocuments = new List<string>();
            
            foreach (var block in _markdown.Blocks)
            {
                var inlines = new MarkdownInline[0];
                switch (block)
                {
                    case ParagraphBlock paragraph:
                        inlines = paragraph.Inlines.ToArray();
                        break;
                    case TableBlock table:
                        inlines = table.Rows
                            .SelectMany(row => row.Cells)
                            .SelectMany(cell => cell.Inlines)
                            .ToArray();
                        break;
                }
                    
                foreach (var inline in inlines)
                {
                    if (!(inline is MarkdownLinkInline mdLink)) continue;
                    
                    var url = mdLink.Url;
                    if (url == null)
                    {
                        Console.WriteLine($"{_fileName}: Link without URL {mdLink.ReferenceId}");
                        continue;
                    }
                    referencedDocuments.Add(url);
                }
            }

            return referencedDocuments;
        }

    }
}