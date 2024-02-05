namespace Program;
using System.IO;
using System.Text;
using HtmlAgilityPack;
class LoadUsingHtmlFile
{
    const string htmlText = @"<!doctype html>
        <html>
            <head>
                <meta charset=""utf-8"" />
                <title>Test Page</title>
            </head>
            <body>
                <a href=""https://github.com/IgorPetrovcm"">My_GitHub</a>
            </body>
        </html>";
    //create file using library
    static void CreateFileUsingLib()
    {
        HtmlDocument doc = new HtmlDocument();

        doc.LoadHtml(html: htmlText);

        doc.Save(filename: "index2.html");
    }
    //manual create html file
    static void ManualCreateFile() 
    {
        Encoding encoding = Encoding.UTF8;
        byte[] htmlTextBytes = encoding.GetBytes(s: htmlText);

        string htmlFilePath = Directory.GetCurrentDirectory() + "/index.html";
        if (File.Exists(path: htmlFilePath)) File.Delete(path: htmlFilePath);

        using (FileStream file = File.Create(path: htmlFilePath))
        {
            file.Write(buffer: htmlTextBytes);
        }
    }
    static void Main()
    {
        ManualCreateFile();
        CreateFileUsingLib();

        //parsing file(manual create)
        try
        {
            if (!File.Exists("index.html")) 
                throw new FileNotFoundException();

            HtmlDocument doc = new HtmlDocument();
            doc.Load("index.html");
            HtmlNode node = doc.DocumentNode.SelectSingleNode("//body");
            System.Console.WriteLine(node.OuterHtml);
        }
        catch (Exception ex) 
        {
            System.Console.WriteLine(ex.Message);
        }
    
        //parsing file(library create)
        try 
        {
            if (!File.Exists("index2.html"))
                throw new FileNotFoundException();
            
            HtmlDocument doc = new HtmlDocument();
            doc.Load("index2.html");
            HtmlNode node = doc.DocumentNode.SelectSingleNode("//body");
            System.Console.WriteLine(node.OuterHtml);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}