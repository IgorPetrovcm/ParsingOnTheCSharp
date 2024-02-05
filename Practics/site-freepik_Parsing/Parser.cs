namespace Parsing;

using HtmlAgilityPack;

public class Parser
{
    private HtmlDocument? _document;

    private string? _mainUrl;

    public Parser(string mainUrl)
    {
        _mainUrl = mainUrl;
    }

    
}