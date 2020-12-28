using System.Collections.Generic;
using System.Diagnostics;

namespace MarkdownToPdf
{
    [DebuggerDisplay("{" + nameof(Name) + "}")]
    public class Book
    {
        public string Name { get; private set; }

        public List<Document> Documents { get; private set; }
        
        public Book(string name)
        {
            Name = name;
            Documents = new List<Document>();
        }


    }
}