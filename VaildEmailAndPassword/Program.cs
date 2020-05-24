using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VaildEmailAndPassword
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("How many testfall do you have to check email?");
            int target = int.Parse(Console.ReadLine());                                    
            
            CheckEmail(target);
        }

        public static void CheckEmail(int target)
        {

            Console.WriteLine("Enter different email separating wtih space");
            String str = Console.ReadLine();
            String[] strArr = str.Split();
            string[] strArrRes = new string[target];
            
            
            for (int i = 0; i < target; i++)
            {
                bool res = IsValidEmail(strArr[i]);
                if (res == true)
                {
                    strArrRes[i] = "PASS";
                }else
                {
                    strArrRes[i] = "FALSE";
                }
            }

            for (int j = 0; j < strArrRes.Length; j++)
            {
                Console.WriteLine(strArrRes[j]);
            }
        }
        
        static bool IsValidEmail(string strEmail)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(strEmail, pattern))
            {
                return true;
            }else
            {
                return false;
            }

        }       

    }
}
