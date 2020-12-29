using System.Collections.Generic;
using System.Diagnostics;

namespace MarkdownBook
{
    [DebuggerDisplay("{" + nameof(Name) + "}")]
    public class Book
    {
        public string Name { get; private set; }

        public List<Chapter> Chapters { get; private set; }
        
        public Book(string name)
        {
            Name = name;
            Chapters = new List<Chapter>();
        }


    }
}