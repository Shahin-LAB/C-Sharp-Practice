using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplacePlaceWithUnderScore
{
    public static class Program
    {
        static void Main(string[] args)
        {
            string str1 = "This is Shahin";
            var superStrip = SuperStrip(str1);
            Console.WriteLine(superStrip);

            string str2 = "    This is Shahin";
            var removeLeadSpace = RemoveLeadSpace(str2);
            Console.WriteLine(removeLeadSpace);


            string str3 = "This is Shahin       ";
            var removeTrailingSpace = RemoveTrailingSpace(str3);
            Console.WriteLine(removeTrailingSpace);

            string str4 = "This is Shahin";
            var replaceLowerAWithUpperA = ReplaceLowerAWithUpperA(str4);
            Console.WriteLine(replaceLowerAWithUpperA);
        }

        public static string SuperStrip(this string InputString)
        {
            if (string.IsNullOrWhiteSpace(InputString))
                return string.Empty;

            return InputString.Replace(" ", "_");
        }

        public static string RemoveLeadSpace(this string InputString)
        {
            if (string.IsNullOrWhiteSpace(InputString))
                return string.Empty;

            return InputString.TrimStart();
        }

        public static string RemoveTrailingSpace(this string InputString)
        {
            if (string.IsNullOrWhiteSpace(InputString))
                return string.Empty;

            return InputString.TrimEnd();
        }

        public static string ReplaceLowerAWithUpperA(this string InputString)
        {            

            char[] arr;            
            char ch1;
            char ch2;
            string res="";            
            arr = InputString.ToCharArray(0, InputString.Length);
            for (int i = 0; i < InputString.Length; i++)
            {
                ch1 = arr[i];
                if (ch1 == 'a')
                {
                    ch2 = Char.ToUpper(ch1);
                    res = res.ToString() + ch2.ToString();
                }
                else
                {
                    res = res.ToString() + ch1.ToString();
                }
            }
            return res;
        }
    }
    
}
