namespace Parsing;

using System.Net;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

public class Parser
{
    private static HttpClient? httpClient;
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

            foreach (HtmlAttribute attribute in nodeWithHref.Attributes)
            {
                if (attribute.Name == "href")
                {
                    urlAddresses.Add(_mainUrl + attribute.Value);
                    break;
                }
            }
        }
        
        foreach (string path in urlAddresses)
        {
            _document = _web.Load(path);

            HtmlNode href = _document.DocumentNode.SelectSingleNode("/html/body/div[3]/span/div[3]/div/div[3]/div[1]/div[2]/div[1]/a");

            

            /*foreach (HtmlAttribute attribute in hrefDownload.Attributes)
            {
                if (attribute.Name == "href")
                {
                    using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _mainUrl + attribute.Value))
                    {
                        try 
                        {
                            httpClient = new HttpClient();

                            HttpResponseMessage response = await httpClient.SendAsync(request);

                            try
                            {
                                FileStream fs = new FileStream(path + Regex.Match(attribute.Value, @"/,\d[1,9],/")+".jpg", FileMode.CreateNew, FileAccess.Write);
                            }
                            catch (Exception ex)
                            {
                                System.Console.WriteLine(ex);
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Console.WriteLine(ex);
                        }
                        


                    }
                }
            }*/
        }
        
    }
}