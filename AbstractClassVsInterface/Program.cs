using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassVsInterface
{
    public abstract class  Customer
    {
        //Abstarct classes --Abstarct classes can have some implementtions for some of its members (Methods)
        // Abstract Member is private by default


        //Abstarct classes --Abstarct classes can have some field
        int ID=0;
        public void Print()
        {
            Console.WriteLine("Print");
            Console.WriteLine(ID);
        }        
    }
    
    public interface ICustomer
    {
        //Build is not successful because of 
        //Interfaces -- But Interfaces can not have some implementation of any of it members

        // Interface members is public by default
        //Interfaces -- Interfaces members cannnot have acess modifiers

        //public void Print()
        //{
        //    Console.WriteLine("Print");
        //}

        //Interface-- It's accepted

        void Print();

        //Interfaces -- But Interfaces can not have some filed
        //int ID;
    }



    class Program
    {
        static void Main(string[] args)
        {
            //Abstarct classes --Abstarct classes can have some implementtions for some of its members (Methods)
            //Interfaces -- But Interfaces can not have some implementation of any of it members

            //Abstarct classes --Abstarct classes can have some field
            //Interfaces -- But Interfaces can not have some filed

            //Abstarct classes --Abstarct classes can inherit another abstact class or another interface
            //Interfaces -- Interfaces can inherit another interface but can not inherit abstact class

            //Classes --Classes can inherit from multiple interface at the same time 
            //where as a class can not inherit multiple classes at the same time


            //Abstarct classes --Abstarct classes can have access modifiers
            //Interfaces -- Interfaces members cannnot have acess modifiers

        }
    }
}
