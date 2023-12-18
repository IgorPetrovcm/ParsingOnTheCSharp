# Шаблон загрузки html со страницы в парсер
Библиотека **HtmlAgilityPack** предоставляет класс `HtmlWeb`:
```csharp
web = new HtmlWeb();
```
его статический метод `Load()` возвращает экземпляр класса `HtmlDocument`, а принимает **строку**, хранящуюю полный **URL** адрес , **html-документ** которого мы хотим получить:
```csharp
doc = web.Load("https://github.com");
``` 
Полный код:
```csharp
string htmlAddress = "https://github.com";

web = new HtmlWeb();

doc = web.Load(htmlAddress);

HtmlNode node = doc.DocumentNode.SelectSingleNode("//head/title");

System.Console.WriteLine(node.InnerText);

GetTitlePages();
```

А также общая практика нетворка:
```csharp
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
```