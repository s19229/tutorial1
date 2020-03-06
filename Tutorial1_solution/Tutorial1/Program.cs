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
            var websiteUrl = args.Length > 0 ? args[0] : throw new ArgumentNullException();
            //websiteUrl = null;
            var x = websiteUrl ?? throw new ArgumentException("the url is null");
            if(websiteUrl == null)
            {
                throw new ArgumentException("nah");
            }
            var httpClient = new HttpClient();

            try
            {
                var respnse = await httpClient.GetAsync(websiteUrl);
                if (respnse.IsSuccessStatusCode)
                {
                    var htmlContent = await respnse.Content.ReadAsStringAsync();

                    var regex = new Regex("[a-z0-9]+[a-z0-9]*@[a-z]+\\.[a-z]+", RegexOptions.IgnoreCase);
                    var emailAddresses = regex.Matches(htmlContent);
                    if(emailAddresses.Count > 0)
                    {
                        foreach (var match in emailAddresses)
                        {
                            Console.WriteLine(match.ToString());
                        }
                    } else
                    {
                        Console.WriteLine("no email addresses found");
                    }
                   
                }

            } 
            catch(Exception)
            {
                Console.WriteLine("error");
            }
          
            Console.WriteLine("dev");
        }
     
    }
}
