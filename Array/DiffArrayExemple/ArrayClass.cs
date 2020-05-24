using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffArrayExemple
{
    public class ArrayClass
    {
        //test for array
        

        public void CallArrayAndPrintData()
        {
            int var1 = 10;
            int var2 = 20;

            ArrayList array1 = new ArrayList();
            array1.Add(var1);
            array1.Add(var2);

            //those works även no compile error:

            //var2 = (int)array1[0];
            var2 = Convert.ToInt32(array1[1]);

            //Console.WriteLine(array1[0]);
            //Console.WriteLine(array1[1]);
            Console.WriteLine(array1.Count);
            Console.WriteLine(array1.Capacity);
            PrintValues(array1);

            //var2 = ((int[])array1)[0];

        }
        private static void PrintValues(IEnumerable myList)
        {
            foreach (Object obj in myList)
                Console.Write("   {0}", obj);
            Console.WriteLine();

        }        
        public void TestArraryWithDifferentOutput()
        {

            Console.WriteLine("..........1. NO, Because of it will create en infinate loop...........");
            //1. NO, Because of it will create en infinate loop
            //Goal : 1,3,6,10,15

            //int[] array1 = { 1, 2, 3, 4, 5 };
            //int sum = 0;
            //for (int i = 0; i < array1.Length;)
            //{
            //    sum += array1[i];

            //    //SAME

            //    //sum = sum + array1[i];
            //    //array1[i++] = sum;
            //}
            //foreach (var item in array1)
            //{
            //    Console.WriteLine(item);
            //}

            Console.WriteLine("..........7. NO, Because of it will create en infinate loop...........");

            //7.NO,Result =1,3,6,10,15
            //funkar INTE to printa ut {1,3,6,10,15}, because of it's not increment the coordinate of i. it will make a infinate loop.

            //int[] intarray7 = { 1, 2, 3, 4, 5 };
            //for (int i = 0; i < intarray7.Length;)
            //{
            //    intarray7[i] += intarray7[i];
            //}

            //foreach (var item in intarray7)
            //{
            //    Console.WriteLine(item);
            //}


            Console.WriteLine("..........2. NO, Because of it will print 2,4,6,8,10...........");
            //2.NO, Result : 2,4,6,8,10 
            //Because of 1+1=2
            //2+2=4
            //3+3=6
            //4+4=8
            //5+5=10

            int[] array2 = { 1, 2, 3, 4, 5 };
            for (int i = 0; i < array2.Length; i++)
            {
                array2[i] += array2[i];
                //SAME
                //array2[i] = array2[i] + array2[i];
            }
            foreach (var item in array2)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("..........3. YES, Because of it stated from 1...........");
            //3.YES,Result =1,3,6,10,15
            //Because of it stated from 1
            //i=1, then 1
            //i=2, then 2+(2-1)=3
            //i=3, then 3+(3-1)
            int[] array3 = { 1, 2, 3, 4, 5 };
            for (int i = 1; i < array3.Length; i++)
            {
                //array1[i] += array1[i-1];
                //SAME
                array3[i] = array3[i] + array3[i - 1];
            }
            foreach (var item in array3)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("..........//4.NO,because of it will update the sum4 value correctly but not the intarray4 which will print out ...........");

            //4.NO,because of it will update the sum4 value correctly but not the intarray4 which will print out 
            //funkar inte to printa ut {1,3,6,10,15}

            int[] intarray4 = { 1, 2, 3, 4, 5 };
            int sum4 = 0;
            foreach (var item in intarray4)
            {
                sum4 += item;
            }
            foreach (var item in intarray4)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("..........//5.Yes,it will print out 1,3,6,10,15 ...........");
            //5.YES,Result =1,3,6,10,15
            //funkar to print {1,3,6,10,15}

            int[] intarray5 = { 1, 2, 3, 4, 5 };
            int sum5 = 0;
            for (int i = 0; i < intarray5.Length;)
            {
                sum5 += intarray5[i];
                intarray5[i++] = sum5;
            }
            foreach (var item in intarray5)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("..........//6.Yes,it will print out 1,3,6,10,15 ...........");

            //6.YES,Result =1,3,6,10,15
            //funkar to print {1,3,6,10,15}

            int[] intarray6 = { 1, 2, 3, 4, 5 };
            int sum6 = 0;
            for (int i = 0; i < intarray6.Length; i++)
            {
                sum6 += intarray6[i];
                intarray6[i] = sum6;
            }
            foreach (var item in intarray6)
            {
                Console.WriteLine(item);
            }



            Console.WriteLine("..........//8.NO,it will print out 1,2,4,4,9 ...........");
            //8.NO,Result =1,3,6,10,15
            //funkar inte to print {1,3,6,10,15}

            int[] intarray8 = { 1, 2, 3, 4, 5 };
            int sum8 = 0;
            for (int i = 0; i < intarray8.Length; i++)
            {
                sum8 += intarray8[i];
                intarray8[i++] = sum8;
            }

            foreach (var item in intarray5)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("..........//9.NO,it will print out 2,4,6,8,10 ...........");
            //9.NO,Result =1,3,6,10,15
            //funkar inte to print { 1,3,6,10,15}, It will print 2,4,6,8,10

            int[] intarray9 = { 1, 2, 3, 4, 5 };

            for (int i = 0; i < intarray9.Length; i++)
            {
                intarray9[i] += intarray9[i];
            }

            foreach (var item in intarray9)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("..........//9.YES,it will print out 1,3,6,10,15 because it strted with i=1...........");
            //10.YES,Result =1,3,6,10,15
            //funkar print { 1,3,6,10,15}, It will print {1,3,6,10,15} because it strted with i=1

            int[] intarray10 = { 1, 2, 3, 4, 5 };

            for (int i = 1; i < intarray10.Length; i++)
            {
                //intarray7[i] += intarray7[i-1];
                //Same
                intarray10[i] = intarray10[i] + intarray10[i - 1];
            }

            foreach (var item in intarray10)
            {
                Console.WriteLine(item);
            }

        }
    }
}
