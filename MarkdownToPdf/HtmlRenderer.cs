using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Toolkit.Parsers.Markdown.Blocks;
using Microsoft.Toolkit.Parsers.Markdown.Inlines;
using Newtonsoft.Json;

namespace MarkdownToPdf
{
    public class HtmlRenderer
    {
        private readonly string _sourcePath;

        public HtmlRenderer(string sourcePath)
        {
            _sourcePath = sourcePath;
        }
        
        public StringBuilder RenderBook(Book book)
        {
            var html = new StringBuilder();

            foreach (var document in book.Documents)
            {
                html.Append(RenderDocument(document));
                html.Append("<div style=\"break-after:page\"></div>");
            }

            return html;
        }
        
        // ReSharper disable once MemberCanBePrivate.Global
        public StringBuilder RenderDocument(Document document)
        {
            var html = new StringBuilder();

            html.AppendLine($"<div id={document.Name}></div>");
            
            foreach (var block in document.GetMarkdownBlocks())
            {
                if (block is HeaderBlock headerBlock)
                {
                    html.Append($"<h{headerBlock.HeaderLevel}>");
                    html.Append(RenderInlines(headerBlock.Inlines));
                    html.AppendLine($"</h{headerBlock.HeaderLevel}>");
                }
                else if (block is ParagraphBlock paragraphBlock)
                {
                    html.Append("<p>");
                    html.Append(RenderInlines(paragraphBlock.Inlines));
                    html.AppendLine("</p>");
                }
                else if (block is TableBlock table)
                {
                    html.Append("<table>");
                    foreach (var row in table.Rows)
                    {
                        html.Append("<tr>");
                        foreach (var cell in row.Cells)
                        {
                            html.Append("<td>");
                            html.Append(RenderInlines(cell.Inlines));
                            html.AppendLine("</td>");
                        }
                        html.AppendLine("</tr>");
                    }
                    html.AppendLine("</table>");
                }
                else if (block is CodeBlock code)
                {
                    html.Append("<pre>");
                    html.Append(code.Text);
                    html.AppendLine("</pre>");
                }
                else if (block is HorizontalRuleBlock)
                {
                    html.AppendLine("<hr/>");
                }
                else
                {
                    
                }
            }

            return html;
        }

        private StringBuilder RenderInlines(IEnumerable<MarkdownInline> inlines)
        {
            var html = new StringBuilder();
            foreach (var inline in inlines)
            {
                html.Append(RenderInline(inline));
            }
            return html;
        }
        
        private StringBuilder RenderInline(MarkdownInline inline)
        {
            var html = new StringBuilder();

            if( inline is TextRunInline text)
            {
                var txt = text.Text
                    .Replace("`", "")
                    .Replace("\r\n", "<br/>");
                html.Append(txt);
            }
            else if (inline is BoldTextInline bold)
            {
                html.Append("<b>");
                html.Append(RenderInlines(bold.Inlines));
                html.Append("</b>");
            }
            else if (inline is ItalicTextInline italic)
            {
                html.Append("<i>");
                html.Append(RenderInlines(italic.Inlines));
                html.Append("</i>");
            }
            else if (inline is MarkdownLinkInline link)
            {
                var href = link.Url;
                if (string.IsNullOrEmpty(href))
                {
                    html.Append(RenderInlines(link.Inlines));
                }
                else
                {
                    if (href.EndsWith(".md", StringComparison.InvariantCultureIgnoreCase))
                    {
                        href = "#" + href.Substring(0, href.Length - 3);
                    }
                    html.Append($"<a href={href}>");
                    html.Append(RenderInlines(link.Inlines));
                    html.Append("</a>");
                }
            }
            else if (inline is ImageInline image)
            {
                var imageUrl = Path.Combine(_sourcePath, image.Url);
                html.Append($"<img src=\"{imageUrl}\" title=\"{image.Tooltip}\">");
            }
            else if (inline is CodeInline code)
            {
                html.Append("<code>");
                var codeText = code.Text;
                var pre = false;
                if (codeText.StartsWith("`"))
                {
                    var lang = new Regex("`(\\w+)?").Match(codeText);
                    if (lang.Success)
                    {
                        codeText = codeText.Substring(lang.Groups[1].Value.Length + 1);
                        codeText = RenderCode(lang.Groups[1].Value, codeText);
                    }
                    else
                    {
                        codeText = codeText.Substring(1);
                    }
                    html.Append("<pre>");
                    pre = true;
                    codeText = Environment.NewLine + codeText;
                }
                html.Append(codeText);
                if (pre)
                {
                    html.Append("</pre>");
                }
                html.Append("</code>");
            }
            else if (inline is LinkAnchorInline anchor)
            {
                html.Append(anchor.Raw);
            }
            else
            {
                            
            }

            return html;
        }

        private string RenderCode(string language, string codeText)
        {
            language = language.Trim().ToLower();
            try
            {
                if (language == "json")
                {
                    var obj = JsonConvert.DeserializeObject(codeText.Replace("...", "\"__more__\": \"\""));
                    if (obj != null)
                    {
                        codeText = JsonConvert.SerializeObject(obj, Formatting.Indented)
                            .Replace("\"__more__\": \"\"", "...");
                    }
                }
            }
            catch
            {
                // ignore
            }
            return codeText;
        }
    }
}