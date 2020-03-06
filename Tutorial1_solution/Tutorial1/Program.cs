using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tutorial1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var websiteUrl = args[0];
            var httpClient = new HttpClient();
            var respnse = await httpClient.GetAsync(websiteUrl);
            if(respnse.IsSuccessStatusCode)
            {
                var htmlContent = await respnse.Content.ReadAsStringAsync();

                var regex = new Regex("[a-z0-9]+[a-z0-9]*@[a-z]+\\.[a-z]+", RegexOptions.IgnoreCase);
                var emailAddresses = regex.Matches(htmlContent);
                foreach (var match in emailAddresses)
                {
                    Console.WriteLine(match.ToString());
                }
            }
            Console.WriteLine("dev");
        }
     
    }
}
