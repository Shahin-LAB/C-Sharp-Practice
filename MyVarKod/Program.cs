using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVarKod
{
    class Program
    {
        static void Main(string[] args)
        {
            var MyVar = -11;
            if (MyVar>=0)
            {
                if (MyVar == 0)
                {
                    Console.WriteLine("Noll");
                }
                else if (MyVar < 10)
                {
                    Console.WriteLine("1:10");
                }
                else if (MyVar > 10)
                {
                    Console.WriteLine("11:-");
                }
            }
            if (MyVar < 0)
            {
                if (MyVar > -10)
                {
                    Console.WriteLine("-10:-1");
                }
                else if (MyVar < -10)
                {
                    Console.WriteLine("--:-10");
                }
            }
        }
    }
}
