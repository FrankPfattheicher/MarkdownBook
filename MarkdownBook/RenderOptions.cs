using System.Security.Cryptography.X509Certificates;

namespace MarkdownBook
{
    public class RenderOptions
    {
        public string SourcePath { get; set; }
        public string TargetPath { get; set; }

        public string CssFile { get; set; }

        public bool MultipleFiles { get; set; }
        public bool CopyAssets { get; set; }

        public RenderOptions()
        {
            SourcePath = ".";
            TargetPath = ".";

            MultipleFiles = false;
            CopyAssets = false;
        }
    }
}