using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferendSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("How many data, you want sort ?");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter data, with space : ");
            string str= Console.ReadLine();
            String[] strArr = str.Split();
            
            //Convert string array to int array
            int[] myIntStrArr = Array.ConvertAll(strArr, int.Parse);
            Console.WriteLine("Sotred Data");
            BubbleSort(myIntStrArr);

            //Otherwise add string data to int array

            int[] data = new int[n];
            for (int i = 0; i < n; i++)
            {                
                data[i] = Convert.ToInt32(strArr[i]);                
            }
            Console.WriteLine("Sotred Data");
            BubbleSort(data);

            Console.WriteLine("Sotred Data with constant array size");
            int[] data2 = new int[3];
            data2[0] = 25;
            data2[1] = 35;
            data2[2] = 10;

            BubbleSort(data2);
        }

        public static void BubbleSort(int[] data)
        {
            int i, j;
            int N = data.Length;
            for (j = N-1; j>0; j--)
            {
                for (i = 0; i < j; i++)
                {
                    if (data[i] > data[i + 1])
                        exchange(data, i, i + 1);                   
                }
            }
            foreach (var item in data)
            {
                Console.WriteLine(item.ToString());
            }            
        }

        public static void exchange(int[] data, int i, int j)
        {
            int temporary = 0;
            temporary = data[i];
            data[i] = data[j];
            data[j] = temporary;
        }


    }
}
