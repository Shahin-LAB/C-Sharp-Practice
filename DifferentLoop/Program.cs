using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DifferentLoop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Your Target");
            int target= int.Parse (Console.ReadLine());
            //WhileLoop(target);
            //DoWhileLoop(target);
            ForEachAndForAndWhileLoop(target);
        }

        public static void ForEachAndForAndWhileLoop(int target)
        {
            int[] Numbers = new int[target];

            for (int l = 0; l < target; l++)
            {
                Numbers[l] = 10+l;
            }         
            
            //Numbers[0] = 101;
            //Numbers[1] = 102;
            //Numbers[2] = 103;

            int i = 0;
            int j = 0;

            Console.WriteLine("According to Foreach Loop");
            foreach (int k in Numbers)
            {
                Console.WriteLine(k);
            }

            Console.WriteLine("According to For Loop");

            for (j = 0; j < Numbers.Length; j++)
            {
                Console.WriteLine(Numbers[j]);
            }

            Console.WriteLine("According to while Loop");
            while (i<Numbers.Length)
            {
                Console.WriteLine(Numbers[i]);
                i++;
            }

        }

        public static void DoWhileLoop(int target)
        {
            string UserChoice = string.Empty;
            int start = 0;

            Console.WriteLine("According to DoWhile Loop");

            while (start < target)
            {
                Console.Write(start + " ");
                start = start + 2;
            }
            do
            {
                Console.WriteLine("do you want to continue-Yes or No");
                UserChoice = Console.ReadLine().ToUpper();
                if (UserChoice != "YES" && UserChoice != "NO")
                {
                    Console.WriteLine("Invalid Choice,Please say Yes or No");
                }
            } while (UserChoice != "YES" && UserChoice != "NO");
            
        }

        public static void WhileLoop(int target)
        {
            int start = 0;
            Console.WriteLine("According to While Loop");
            while (start< target)
            {
                Console.Write(start + " ");
                start = start + 2;
            }
        }
    }
}
