# Шаблон загрузки Html файла в парсер
Мы имеем следующий **html** текст:
```csharp
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
```

Библиотека **HtmlAgilityPack** предоставляет возможность быстро создать **.html** файл следующим образом:
```csharp
static void CreateFileUsingLib()
{
    HtmlDocument doc = new HtmlDocument();

    doc.LoadHtml(html: htmlText);

    doc.Save(filename: "index2.html");
}
```
Файл `"index2.html"` будет сохранен в директорию проекта, однако мы можем указать любой путь.

Сохраню здесь также ручной способ создания:
```csharp
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
```

### Реализация загрузки файла в парсер
```csharp
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
```
Единственной отличие от способа с загрузкой самого текста **html**, использования метода `Load`, вместо `LoadHtml`
```csharp
doc.Load("index.html");
```
Мы просто указывает путь к **html-файлу**.