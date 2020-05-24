using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProblemsMultipleClassInheritance
{

    //Is not possible multiple Class Interface
    class A
    {
        public virtual void Print()
        {
            Console.WriteLine("A Implementation");
        }
    }

    class B :A
    {
        //We can Override Print Method if we use virtual keyword
        public override void Print()
        {
            Console.WriteLine("B Implementation");
        }
    }


    class C : A
    {
        //We can Override Print Method if we use virtual keyword
        public override void Print()
        {
            Console.WriteLine("C Implementation");
        }
    }

    //A class cannot inherit multiple class
    //class D : A, B
    //{        
    //}

    class Program
    {
        static void Main(string[] args)
        {
            //D d = new D();
            //d.Print();// ambigity which print method it will call

        }
    }
}
