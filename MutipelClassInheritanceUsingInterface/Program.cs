using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutipelClassInheritanceUsingInterface
{
    public class Program
    {

        interface IA
        {
            void AMethod();
        }

        class A : IA
        {
            public void AMethod()
            {
                Console.WriteLine("A");
            }
        }


        interface IB
        {
            void BMethod();
        }

        class B : IB
        {
            public void BMethod()
            {
                Console.WriteLine("B");
            }
        }

        class AB : IA, IB
        {
            A a = new A();
            B b = new B();
            public void AMethod()
            {
                a.AMethod();
            }

            public void BMethod()
            {
                b.BMethod();
            }
        }

        static void Main(string[] args)
        {
            AB ab = new AB();
            ab.AMethod();
            ab.BMethod();
        }
    }
}
