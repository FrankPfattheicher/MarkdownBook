using System.Security.Cryptography.X509Certificates;

namespace MarkdownBook
{
    public class RenderOptions
    {
        public string SourcePath { get; set; }
        public string TargetPath { get; set; }

        public string CssFile { get; set; }

        public bool SingleFile { get; set; }
        public bool CopyAssets { get; set; }

        public RenderOptions()
        {
            SourcePath = ".";
            TargetPath = ".";

            SingleFile = true;
            CopyAssets = false;
        }
    }
}