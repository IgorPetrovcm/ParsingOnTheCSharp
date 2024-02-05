namespace Png;

using System.Data;
using System.Net.Http;
using System.Runtime.ExceptionServices;
using System.Text;

public class Program 
{
    static HttpClient httpClient;
    static async Task Main()
    {
        using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://cdn1.ozonusercontent.com/s3/test-examples-taskbook-api/48.zip"))
        {
            try 
            {
                httpClient = new HttpClient(); 

                HttpResponseMessage response = await httpClient.SendAsync(request);

                HttpContent content = response.Content;

                using FileStream file = new FileStream("test.zip",FileMode.Create,FileAccess.Write);

                content.CopyToAsync(file);
            }
            catch (Exception ex){
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}