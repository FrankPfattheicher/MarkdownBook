# MarkdownBook
Create documentation from several markdown files.

**How it works**
Starting wit an initial markdown document, 
all linked documents are collected to create complete documentation. 

## Commandline

    MarkdownBook <initialMarkdownDocument> [-c] [-m]

**Options**   
-c : Copy asset files to output directory   
-m : Create multiple output files

## HTML renderer
The HTML renderer supports single or multiple file documentation output.

CSS file is used if available as file named as initial document.

## Future
Due to Microsoft.Toolkit.Parsers is now deprecated,
i have to move to **Markdig**...

https://github.com/xoofx/markdig

---
(c) 2020-2022 ICT Baden GmbH
