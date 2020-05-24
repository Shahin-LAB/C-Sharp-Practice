using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {



        public static void Main()
        {
            //var html = GetAsync("http://www.microsoft.com");
            //GetAsync("https://dotnetfoundation.org");            


            //await ReadCharacters();

        }

        static async Task ReadCharacters()
        {
            String result;
            using (StreamReader reader = File.OpenText("existingfile.txt"))
            {
                Console.WriteLine("Opened file.");
                result = await reader.ReadLineAsync();
                Console.WriteLine("First line contains: " + result);
            }
        }

        public static async Task<string> GetAsync(string uri)
        {
            var httpClient = new HttpClient();
            var content = await httpClient.GetStringAsync(uri);
            return await Task.Run(() => content);
        }

        //public static async Task<string> Main(string uri)
        //{
        //    var httpClient = new HttpClient();
        //    var content = await httpClient.GetStringAsync("http://www.microsoft.com");
        //    return await Task.Run(() => content);
        //}
    }
}
