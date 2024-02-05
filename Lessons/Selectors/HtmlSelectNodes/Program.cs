namespace HtmlSelectNodes;
using HtmlAgilityPack;
using System.Linq;
class Program
{
    const string address_ukit = "https://www.mgkit.org/"; 
    static HtmlDocument document;
    static HtmlWeb webPage;
    static void Main()
    {
        webPage = new HtmlWeb();
        
        document = new HtmlDocument();

        document = webPage.Load(address_ukit);

        HtmlNodeCollection nodes = document.DocumentNode.SelectNodes("//div");
        foreach (HtmlNode node in nodes)
        {
            System.Console.WriteLine(node.InnerText);
        }
    }
}