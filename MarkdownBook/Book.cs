using System.Collections.Generic;
using System.Diagnostics;

namespace MarkdownBook
{
    [DebuggerDisplay("{" + nameof(Name) + "}")]
    public class Book
    {
        public string Name { get; private set; }

        public List<Chapter> Documents { get; private set; }
        
        public Book(string name)
        {
            Name = name;
            Documents = new List<Chapter>();
        }


    }
}