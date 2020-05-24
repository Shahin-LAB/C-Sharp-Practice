using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var str= FormatCoins("Shahin",0);

            int e = 1;
            int f = 10;
            int g = 0;
            int h = 1000;
            string i = string.Format("number are:{0:D3} - {1:D3} and {2:D3} and {2:D4}", e, f, g,h);
        }
        public static string FormatCoins(string name, int coins)
        {
            return string.Format("Player {0}, collected coins {1}", name, coins.ToString("###0"));//-----I think this is correct

            //return string.Format("Player {0} collected coins {1:000#}", name, coins);//---------NOT CORRECT

            //return string.Format("Player {1} collected coins {2:D3}", name, coins);//---------NOT CORRECT

        }

    }
}
