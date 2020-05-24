using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleAbstructClass
{
    public class PrefixAndPostfix
    {
        public void prefixAndPostfix()
        {

            // Postfix increment operator
            // The result of x++ is the value of x before the operation, as the following example shows:

            int i = 3;
            Console.WriteLine(i);   // output: 3
            Console.WriteLine(i++); // output: 3
            Console.WriteLine(i);   // output: 4


            //Prefix increment operator
            //The result of++x is the value of x after the operation, as the following example shows:

            double a = 1.5;
            Console.WriteLine(a);   // output: 1.5
            Console.WriteLine(++a); // output: 2.5
            Console.WriteLine(a);   // output: 2.5


            //Postfix decrement operator
            //The result of x-- is the value of x before the operation, as the following example shows:
            int j = 3;
            Console.WriteLine(j);   // output: 3
            Console.WriteLine(j--); // output: 3
            Console.WriteLine(j);   // output: 2

            //Prefix decrement operator
            //The result of--x is the value of x after the operation, as the following example shows:

            double b = 1.5;
            Console.WriteLine(b);   // output: 1.5
            Console.WriteLine(--b); // output: 0.5
            Console.WriteLine(b);   // output: 0.5

            //So

            int c = 3, d = 4, e = 5;
            //Console.WriteLine(--c); // So it Prefix decrement 3-1=2
            //Console.WriteLine(--c * d); // 2 * 4= 8
            
            //Console.WriteLine(++e); // So, Prefix increment 5+1=6

            Console.WriteLine(--c*d-++e); //8-6 =2
        }
        
    }
}
