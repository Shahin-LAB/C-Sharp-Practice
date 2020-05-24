using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExempleQA483
{
    public class TestWebURL
    {
        
        public void testWebURL()
        {

        }
        public void TestIfWebSite(string url)
        {
            const string pattern = @"http://(www\.)?([^\.]+)\.com";
            List<string> result = new List<string>();
            MatchCollection myMatches = Regex.Matches(url, pattern);

            foreach (Match currentMatch in myMatches)
            {
                //result.Add(currentMatch.Groups.ToString());
                result.Add(currentMatch.Value);
            }

            //return result;
            result.ForEach(Console.WriteLine);

        }
    }

    
}
