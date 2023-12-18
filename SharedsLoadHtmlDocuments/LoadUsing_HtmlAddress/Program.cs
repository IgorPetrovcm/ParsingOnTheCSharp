namespace LoadUsing_HtmlAddress;
using HtmlAgilityPack;
class Program
{
    static Uri uri;
    static HtmlWeb web;
    static HtmlDocument doc;
    static void Main()
    {
        string htmlAddress = "https://github.com";

        web = new HtmlWeb();

        doc = web.Load(htmlAddress);

        HtmlNode node = doc.DocumentNode.SelectSingleNode("//head/title");

        System.Console.WriteLine(node.InnerText);

        GetTitlePages();
    }

    static void GetTitlePages()
    {
        while (true)
        {
            System.Console.WriteLine("Input url: ");
            uri = new Uri(Console.ReadLine());

            web = new HtmlWeb();

            doc = web.Load(uri.OriginalString);

            HtmlNode node = doc.DocumentNode.SelectSingleNode("//head/title");

            System.Console.WriteLine(node.InnerText);
        }
    }
}