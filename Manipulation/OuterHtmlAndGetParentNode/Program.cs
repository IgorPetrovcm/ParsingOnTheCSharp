namespace OuterHtmlAndGetParentNode;
using HtmlAgilityPack;
class Program 
{
    const string htmlText = @"<!doctype html>
    <head>
        <meta charset=""utf-8""/>
        <title>Hello Task</title>
    </head>
    <body>
        <h1>Hello <b>first</b> user</h1>
        <h1>Hello <i>first</i> user</h1>
    </body>";
    static void Main() 
    {
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(htmlText);

        HtmlNode node = doc.DocumentNode.SelectSingleNode("//body/h1");

        System.Console.WriteLine(node.ParentNode.Name);
    }
}