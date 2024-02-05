namespace Parsing;

using HtmlAgilityPack;

public class Parser
{
    private HtmlDocument? _document;

    private static HtmlWeb _web = new HtmlWeb();

    private readonly string _mainUrl = "https://zastavok.net/";

    private Uri? _currentUrl;

    public Parser()
    {
    }

    public void DownloadPictures(string srcPath)
    {
        _document = _web.Load(_mainUrl);

        HtmlNodeCollection collection = _document.DocumentNode.SelectNodes("/html/body/div[3]/div[3]/div[4]/div");

        HtmlNode node1 = _document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[4]/div[1]/div/div[1]/a");

        foreach (HtmlNode node in collection) 
        {
            HtmlNode nodeWithHref = node.SelectSingleNode("div/div[1]/a");

            
        }
    }
}