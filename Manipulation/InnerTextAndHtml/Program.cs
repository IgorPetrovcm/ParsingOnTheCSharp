namespace Program ;
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
}