using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleOfDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var ret0 = FindInList("Finance", 0);
            Console.WriteLine(ret0);
            var ret1= FindInList("Accounting", 1);
            Console.WriteLine(ret1);
            var ret2 = FindInList("Accounting", 2);
            Console.WriteLine(ret2);

        }
        public static Dictionary<string, int> CreateTestData()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
        {
            {"Accounting",1},
            {"Markteing",2},
            {"Operations",3 }
        };
            return dict;
        }
        private static bool? FindInList(string sercahitem, int value)
        {
            Dictionary<string, int> data = CreateTestData();
            return data.Contains(new KeyValuePair<string, int>(sercahitem,value));
        }
    }

    
        
}
