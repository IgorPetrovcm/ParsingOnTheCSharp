namespace Program
{
    using HtmlAgilityPack;
    using System.Net.Http;
    class Program
    {
        static HttpClient client = new HttpClient();
        static async Task Main()
        {
            HtmlDocument doc = new HtmlDocument();
            HtmlWeb web = new HtmlWeb();
            doc = web.Load("https://ria.ru/");
            HtmlNode node = doc.DocumentNode.SelectSingleNode(@"//*[@id=""content""]/div/div[2]/div[1]/div[1]/div[1]/div[5]/div/div/div/div/div");
            HtmlNodeCollection collection = node.ChildNodes;

            foreach (HtmlNode a in collection)
            {
                System.Console.WriteLine(a.SelectSingleNode("a").InnerText);
            }
        }   
    }
}