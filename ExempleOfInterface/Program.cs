using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleOfInterface
{

    interface ICustomer
    {
        void Print();
    }
    interface I2
    {
        void I2Method();
    }
    public class Customer : ICustomer, I2
    {
        //Implementation of I2 Interface
        public void I2Method()
        {
            Console.WriteLine("I2 method");
        }

        //Implementation of ICustomer Interface
        public void Print()
        {
            Console.WriteLine("interface Print Method");
        }
    }
    public class Sample : Customer
    {


    }


    interface IInterface1
    {
        void InterfaceMethod();

    }
    interface IInterface2
    {
        void InterfaceMethod();

    }

    class TestInterfaceClass : IInterface1, IInterface2
    {
        //Implicit Implementation or default Interface
        public void InterfaceMethod()
        {
            Console.WriteLine("Both have same method");
        }

        //Explicit Implementation
        void IInterface1.InterfaceMethod()
        {
            Console.WriteLine("Interface method 1");
        }

        void IInterface2.InterfaceMethod()
        {
            Console.WriteLine("Interface method 2");
        }


    }

    //--------------Question 483-------
    public class Class1:Class2
    {

    }

    public interface INewInterface
    {
        void Method1();
    }

    public class Class2 : INewInterface
    {
        void INewInterface.Method1()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Call INewInterface.Method1");
        }
    }

    class Program : Sample
    {
        

        public static void Main()
        {


            Console.WriteLine("-----Customer class who has inherited to another interface ICustomer-------------------");
            Customer customer = new Customer();
            customer.Print();

            Console.WriteLine("-----Sample class inhireted to Customer class who inherited to another interface ICustomer-------------------");
            Sample sample = new Sample();
            sample.Print();
            sample.I2Method();


            Console.WriteLine("------------------------");
            ICustomer cust = new Sample();
            cust.Print();
            I2 testInter = new Sample();
            testInter.I2Method();

            Console.WriteLine("------------Some ambiguity of the Interface method, Implicit Implementation of Interface------------");
            TestInterfaceClass testInterfaceClass = new TestInterfaceClass();
            testInterfaceClass.InterfaceMethod();

            Console.WriteLine("------------Explicit Implementation of Interface------------");
            ((IInterface1)testInterfaceClass).InterfaceMethod();
            ((IInterface2)testInterfaceClass).InterfaceMethod();
            Console.WriteLine("------------Another way, Explicit Implementation of Interface------------");

            IInterface1 iInterface1 = new TestInterfaceClass();
            IInterface2 iInterface2 = new TestInterfaceClass();
            iInterface1.InterfaceMethod();
            iInterface2.InterfaceMethod();

            //Question 483


            Console.WriteLine("------------Call a method from interface------------");

            //Question 1 : If you call Method1 from an instance of Class2.
            //Exception will occur
            Class2 class2 = new Class2();
            //class2.Method1()---Is not Possible to Call Method 1

            Console.WriteLine("-------------");
            //but is possible like this way
            ((INewInterface)class2).Method1();
            //oR
            INewInterface newInterface = new Class2();
            newInterface.Method1();

            Console.WriteLine("-------------");
            //Question 2 : If you cast an instance of Class1
            Class1 class1 = new Class1();
            ((INewInterface)class1).Method1();


        }
    }
}
