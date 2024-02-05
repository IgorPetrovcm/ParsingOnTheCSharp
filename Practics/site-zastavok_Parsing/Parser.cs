namespace Parsing;

using System.Net;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

public class Parser
{
    private HttpClient httpClient;
    private static HtmlDocument? _document;

    private static HtmlWeb _web = new HtmlWeb();

    private readonly string _mainUrl = "https://zastavok.net";

    private Uri? _currentUrl;

    public Parser()
    {
    }

    public async Task DownloadPictures(string srcPath)
    {
        List<string> urlAddresses = new List<string>();

        _document = _web.Load(_mainUrl);

        HtmlNodeCollection collection = _document.DocumentNode.SelectNodes("/html/body/div[3]/div[3]/div[4]/div");

        foreach (HtmlNode node in collection) 
        {
            HtmlNode? nodeWithHref = node.SelectSingleNode("div/div[1]/a");

            urlAddresses.Add(_mainUrl + nodeWithHref.Attributes["href"].Value);

        }
        
        foreach (string path in urlAddresses)
        {
            _document = _web.Load(path);

            HtmlNode hrefDownload = _document.DocumentNode.SelectSingleNode("/html/body/div[3]/span/div[3]/div/div[3]/div[1]/div[2]/div[1]/a");

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _mainUrl + hrefDownload.Attributes["href"].Value))
            {
                    try 
                    {
                        httpClient = new HttpClient();

                        HttpResponseMessage response = httpClient.SendAsync(request).Result;

                    
                        FileStream fs = new FileStream(srcPath + Regex.Match(
                                hrefDownload.Attributes["href"].Value, @"\d{1,9}")+".jpg",
                                    FileMode.Create, FileAccess.Write);
                        
                        response.Content.CopyToAsync(fs);
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex);
                    }
            }
        }
        
    }
}