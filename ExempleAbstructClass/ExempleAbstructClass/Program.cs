using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleAbstructClass
{
    class Program
    {
        public static void Main()
        {

            // It's possible to implement the BaseEmployee Class implementation, Programmer can do this. Because of BaseEmployee Class as a concreat Class
            // It's possible to build but not possible to run. 
            // To avoid this make BaseEmployee Class as abstract class
            //BaseEmployee be = new BaseEmployee()
            //{
            //    ID = 3,
            //    FirstName = "Not implemented",
            //    LastName = "COZ Concreat Class"
            //};
            //Console.WriteLine(be.GetfullName());


            //but you can achieve it by removing the following class as well as override keyword and //Console.WriteLine(be.GetMonthlySalary());
            //public virtual int GetMonthlySalary()
            //{
            //    throw new NotImplementedException();
            //}

            // So the programmer can still can create the instance of BaseEmployee Class.You should avoid it. So that make it is abstract.
            //then the programmer can not able to create the 
            //BaseEmployee be = new BaseEmployee()
            //{
            //    ID = 3,
            //    FirstName = "Not implemented",
            //    LastName = "COZ Concreat Class"
            //};
            //Console.WriteLine(be.GetfullName());


            //FullTimeEmployee fte = new FullTimeEmployee()
            //{
            //    ID = 1,
            //    FirstName = "Shahin",
            //    LastName = "Rohman",
            //    AnnualSalay = 60000
            //};
            //Console.WriteLine(fte.GetfullName());
            //Console.WriteLine(fte.GetMonthlySalary());

            //Console.WriteLine("-------------------------------------");

            //ContractEmployee cte = new ContractEmployee()
            //{
            //    ID = 2,
            //    FirstName = "Zinia",
            //    LastName = "Rohman",
            //    HourlyPay = 200,
            //    TotalHoursWorked = 40,
            //};
            //Console.WriteLine(cte.GetfullName());
            //Console.WriteLine(cte.GetMonthlySalary());


            //Exemple of Prefix and Postfix
            //PrefixAndPostfix prefixAndPostfix = new PrefixAndPostfix();
            //prefixAndPostfix.prefixAndPostfix();

            ExempleInterface exeInt = new ExempleInterface();
            exeInt.exempleInterface();





        }
    }
}
