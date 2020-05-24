using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EricssonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Given a number n for each interger i in the range from 1 to n inclusive, print ont value per line as follows:

            // if i is a multiple of both 3 and 5, print FizzBuzz
            // if i is a multiple of both 3 but not 5, print Fizz
            // if i is a multiple of both 5 but not 3, print Buzz
            // if i is a not multiple of both 3 or 5, print of the values i;

            fizzBuzz();

            //addingIterationNumber();

            
        }

        private static void addingIterationNumber()
        {
            Console.WriteLine("How many time do you want to this adding iteration ?");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int t = 0; t < n; t++)
            {
                Console.WriteLine("Enter two different value with space");
                String str = Console.ReadLine();
                String[] strArr = str.Split();
                int a = Convert.ToInt32(strArr[0]);
                int b = Convert.ToInt32(strArr[1]);
                Console.WriteLine(a + b);
            }
        }

        public static void fizzBuzz()
        {
            Console.WriteLine("How many time do you want do this fizzbuzz logic?");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
               
                if (i%15 !=0)
                {
                    if (i % 3 == 0)
                        Console.WriteLine("Fizz");
                    else if (i % 5 == 0)
                        Console.WriteLine("Buzz");                    
                    else 
                        Console.WriteLine(i);
                }else
                {   
                    Console.WriteLine("FizzBuzz");
                }
                
            }            
        }        
    }
}
