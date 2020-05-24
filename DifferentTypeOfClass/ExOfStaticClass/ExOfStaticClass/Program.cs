using System;

namespace ExOfStaticClass
{

    //A static class cannot be instantiated.
    class Customer
    {
        string _firstName;
        string _lastName;

        public Customer() : this("No FirstName Provide", "No LastName Provide")
        {

        }

        public Customer(string FirstName, string LastName)
        {
            this._firstName = FirstName;
            this._lastName = LastName;
        }

        public void PrintFullName()
        {
            Console.WriteLine("Full Name  = {0}", this._firstName + " " + this._lastName);
        }
        ~Customer()
        {
            //Destructor, Clean up code
        }

    }

    public static class HightConverter
    {
        public static double InchsToCentimeter(string HightInInchs)
        {
            double inchs = double.Parse(HightInInchs);
            double centimeter = inchs * 2.54;
            return centimeter;
        }
        public static double CentimerterToInchs(string HightInCentimeter)
        {
            double centimeter = double.Parse(HightInCentimeter);
            double inchs = centimeter / 2.54;
            return inchs;
        }
    }


    class Program
    {
        public static void Main()
        {
            //Console.WriteLine("Hello World!");

            //Constructor used with no parameter
            Customer C1 = new Customer();
            C1.PrintFullName();
            
            //Constructor used with parameter
            Customer C2 = new Customer("Shahin", "Rohman");
            C2.PrintFullName();


            //
            Console.WriteLine("Please Select the Converstion Direction.");
            Console.WriteLine("1. From Inchs to Centimert");
            Console.WriteLine("2. From Centimert to Inchs ");

            string selection = Console.ReadLine();

            switch (selection )
            {
                case "1":
                    Console.WriteLine ("Please enter the hight of inchs");
                    double C = HightConverter.InchsToCentimeter(Console.ReadLine());
                    break;
                case "2":
                    Console.WriteLine("Please enter the hight of centimeter");
                    double I = HightConverter.CentimerterToInchs (Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Please select the ");
                    break;
            }
                
            Console.ReadKey();

        }
    }
}
