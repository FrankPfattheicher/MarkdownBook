
# MarkdownBook.Test


# *Headers*

H1
==

H2
--

# H1
## H2
### H3
#### H4
##### H5


# *Block Quotes*

> block quote 1
> > block quote 2
> > > block quote 3


# *Lists*

*   Red
*   Green
*   Blue

+   Red
+   Green
+   Blue

-   Red
-   Green
-   Blue

1.  Bird
1.  McHale
1.  Parish


First Term
: This is the definition of the first term.

Second Term
: This is one definition of the second term.
: This is another definition of the second term.


# *Paragraph*

This is a normal paragraph.


# *Code*

    This is a code block.


Use the `printf()` function.


```json
{
  "firstName": "John",
  "lastName": "Smith",
  "age": 25
}
```

# *Horizontal Rules*

* * *

***

*****

- - -

---------------------------------------


# *Emphasis* 

*single asterisks*

_single underscores_

**double asterisks**

__double underscores__

~~strike though~~


test * test * test

test \*test\* test


# *Images*

![Alt text](img.png)

![Alt text](img.png "Image title")


# *Backslash Escapes*

\\   backslash    
\`   backtick    
\*   asterisk    
\_   underscore    
\{\}  curly braces    
\[\]  square brackets    
\(\)  parentheses    
\#   hash mark    
\+   plus sign    
\-   minus sign (hyphen)    
\.   dot    
\!   exclamation mark    


# *Icon Symbols*

see https://gist.github.com/rxaviers/7360908

|> Play   
<*> :star: Asterisk   
{o} Gear   
/!\ Alert   
(-) :no_entry: Prohibition   
(?) Question   
(i) Info   
(c) Copyright    
&copy; Copyright    

:smile: Smiley    
Gone camping! :tent: Be back soon.    
That is so funny! :joy:    


# *Page Break*
<div style="page-break-after: always;"></div>


# *Check Boxes*

[ ] unchecked  
[x] checked    
[/] ok checked


# *Tables*

| Syntax      | Description |
| ----------- | ----------- |
| Header      | Title       |
| Paragraph   | Text        |


| Syntax      | Description | Test Text     |
| :---        |    :----:   |          ---: |
| Header      | Title       | Here's this   |
| Paragraph   | Text        | And more      |


# *Super and Subscript*

20^th century    
H~2~O    
H<sub>2</sub>O


# *Specifying Style*

item **bold red**{style="color:red"}


# *Footnotes*

Here's a simple footnote,^*1 and here's a longer one.^(bignote)

*1: This is the first footnote.

(bignote): Here's one with multiple paragraphs and code.

    Indent paragraphs to include them in the footnote.

    `{ my code }`

    Add as many paragraphs as you like.


(c) 2020-2021 ICT Baden GmbH
