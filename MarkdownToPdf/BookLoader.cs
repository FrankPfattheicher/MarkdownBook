using System;
using System.Collections.Generic;
using System.IO;

namespace MarkdownToPdf
{
    public class BookLoader
    {
        private readonly string _bookName;
        private readonly string _documentPath;
        private readonly List<string> _documentFiles;

        public BookLoader(string initialDocument)
        {
            _documentPath = Path.GetDirectoryName(initialDocument);
            _bookName = Path.GetFileNameWithoutExtension(initialDocument);
            _documentFiles = new List<string>
            {
                Path.GetFileName(initialDocument)
            };
        }

        public Book Load()
        {
            var book = new Book(_bookName);

            for (var documentIndex = 0; documentIndex < _documentFiles.Count; documentIndex++)
            {
                var documentFile = Path.Combine(_documentPath, _documentFiles[documentIndex]);
                if (!File.Exists(documentFile))
                {
                    Console.WriteLine("Could not find " + documentFile);
                    continue;
                }
                Console.WriteLine("Processing " + documentFile);
                var document = new Document(documentFile);
                book.Documents.Add(document);
                
                foreach (var referencedDocument in document.GetReferencedDocuments())
                {
                    if (!_documentFiles.Contains(referencedDocument))
                    {
                        _documentFiles.Add(referencedDocument);
                    }
                }
            }


            return book;
        }
        
    }
}