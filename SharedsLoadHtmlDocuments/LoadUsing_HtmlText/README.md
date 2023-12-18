# Шаблон загрузки html текста в парсер
```csharp
string htmlText = @"<!doctype html>
        <html>
            <head>
                <meta charset=""utf-8"" />
                <title>Test Page</title>
            </head>
            <body>
                <a href=""https://github.com/IgorPetrovcm"">My_GitHub</a>
            </body>
        </html>";

HtmlDocument document = new HtmlDocument();
document.LoadHtml(html: htmlText);

HtmlNode nodeBody = document.DocumentNode.SelectSingleNode(xpath: "//body");
System.Console.WriteLine(nodeBody.OuterHtml);
        
HtmlNode nodeHref = document.DocumentNode.SelectSingleNode(xpath: "//body/a");
System.Console.WriteLine(nodeHref.OuterHtml);

HtmlNode nodeHref2 = document.DocumentNode.SelectSingleNode(xpath: "//a"); // не "/a"
System.Console.WriteLine(nodeHref2.OuterHtml);
```