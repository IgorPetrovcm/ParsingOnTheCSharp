# InnerHtml и InnerText свойства

`InnerText` и `InnerHtml` свойства класса `HtmlNode`.
при получении экземпляра `HtmlNode` мы можем их применить и узнать что лежит внутри `HtmlNode`.

```csharp
const string htmlText = @"<!doctype html>
    <head>
        <meta charset=""utf-8""/>
        <title>Hello Task</title>
    </head>
    <body>
        <h1>Hello <b>first</b> user</h1>
        <h1>Hello <i>first</i> user</h1>
    </body>";
static HtmlDocument doc = new HtmlDocument();
static void Main()
{
    doc.LoadHtml(htmlText);
        
    HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//body/h1");
        
    foreach (HtmlNode node in nodes)
    {
        System.Console.WriteLine(node.InnerHtml);
            System.Console.WriteLine(node.InnerText);
    }
}
```
Ответ компилятора:
```
Hello <b>first</b> user
Hello first user
Hello <i>first</i> user
Hello first user
```

+ `InnerHtml` возращает полную строку тега, который мы парсили, то есть со всеми внутренними тегами.
+ `InnerText` возращает лишь значение тега, который мы парсили, без внутренних тегов, чистый текст допустим. 
