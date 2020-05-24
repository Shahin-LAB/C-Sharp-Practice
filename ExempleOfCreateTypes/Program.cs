using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ExempleOfCreateTypes
{
    class Program
    {
        public static void Main()
        {



            //string s = "*";
            //Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            //Console.WriteLine(s);
            //Console.ReadKey();

            //int leftOffSet = (Console.WindowWidth / 2);
            //int topOffSet = (Console.WindowHeight / 2);
            //Console.SetCursorPosition(leftOffSet, topOffSet);
            //Console.Write("*");
            //Console.ReadKey();

            //TestExtensionMethod();

            CheckEmailAddress();

            //MoveAstarisk();

        }

        public static void CheckEmailAddress()
        {
            Console.WriteLine("Email:");
            string str = Console.ReadLine();

            var email = new Email();
            var ret=email.CkEmail(str);
            if (ret==true)
                Console.WriteLine(str + " is correct");
            else
                Console.WriteLine(str + " is incorrect");
            
        }

        public static void TestExtensionMethod()
        {
            Console.WriteLine("Product Price : ");
            string pris = Console.ReadLine().ToString();//set
            var prod = new Product();
            prod.Price = decimal.Parse(pris.ToString()); //set

            var calc = new Calculator();

            Console.WriteLine("So get the value : " + prod.Price);//get
            Console.WriteLine("After Discount 10 % :" + calc.CalculatorDiscount(prod));
        }

        public static void MoveAstarisk()
        {

            //int leftOffSet = (Console.WindowWidth / 2);
            //int topOffSet = (Console.WindowHeight / 2);
            //Console.SetCursorPosition(leftOffSet, topOffSet);
            //Console.Write("*");

            const char toWrite = '*'; // Character to write on-screen.
            int x = 0, y = 0; // Contains current cursor position.
            Write(toWrite); // Write the character on the default location (0,0).

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var command = Console.ReadKey().Key;

                    switch (command)
                    {
                        case ConsoleKey.DownArrow:
                            y++;
                            break;
                        case ConsoleKey.UpArrow:
                            if (y > 0)
                            {
                                y--;
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (x > 0)
                            {
                                x--;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            x++;
                            break;
                    }

                    Write(toWrite, x, y);
                }
                else
                {
                    Thread.Sleep(100);
                }

            }
        }
        public static void Write(char toWrite, int x = 0, int y = 0)
        {
            try
            {
                if (x >= 0 && y >= 0) // 0-based
                {
                    Console.Clear();
                    Console.SetCursorPosition(x, y);
                    Console.Write(toWrite);
                }
            }
            catch (Exception)
            {
            }
        }


    }

    public static class ExtensionsMethods
    {
        public static bool IsEmail(this string str)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(str);

            if (match.Success)
                Console.WriteLine(str + " is correct");
            else
                Console.WriteLine(str + " is incorrect");
            return regex.IsMatch(str);
        }
    }

    public class Email
    {
        public bool CkEmail (string str)
        {   
            return str.IsEmail();
        }
    }
    public class Product
    {
        public decimal Price { get; set; }
    }
    public static class MyExtensions
    {
        public static decimal Discount(this Product product)
        {
            return product.Price- product.Price * .1M;
        }
    }

    public class Calculator
    {
        public decimal CalculatorDiscount(Product p)
        {
            return p.Discount();
        }
    }
}
