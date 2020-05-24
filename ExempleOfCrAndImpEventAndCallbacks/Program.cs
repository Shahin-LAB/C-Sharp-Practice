
using System;
using System.Linq;

namespace ExempleOfCrAndImpEventAndCallbacks
{

    class Program
    {
        public delegate void Del();
        public delegate int Calculation(int x, int y);//Delegate            
        public static void Main(string[] args)
        {

            //Summary

            //Delegates are a type that defines a method signature and can contain a reference to a method.
            //Delegates can be instantiated, passed around, and invoked.
            //Lambda expressions, also known as anonymous methods, use the => operator and form a compact way of creating inline methods.
            //Events are a layer of syntactic sugar on top of delegates to easily implement the publish - subscribe pattern.
            //Events can be raised only from the declaring class. Users of events can only remove and add methods the invocation list.
            //You can customize events by adding a custom event accessor and by directly using the underlying delegate type.


            //One thing that is a direct result of the sequential order is how to handle exceptions.
            //LISTING 1 - 87 Manually raising events with exception handling
            ManuallyRaisingEventsExceptionHandling();




            //Although the event implementation uses a public field, you can still customize addition and removal of subscribers. 
            //This is called a custom event accessor
            //LISTING 1 - 85 Custom event accessor
            //CustomEventAccessor();

            //Instead of using the Action type for your event, you should use the EventHandler or EventHandler<T>. 
            //EventHandler is declared as the following delegate:
            //public delegate void EventHandler(object sender, EventArgs e);
            //LISTING 1 - 84 Custom event arguments
            //CustomEventArguments();


            //A reusable solution for a recurring problem
            //Delegates form the basis for the event system in C#. 
            //Listing 1-82 shows how a class can expose a public delegate and raise it.
            //USING 1 - 82 Using an Action to expose an event
            //ActionToExposeEvent();


            //LISTING 1 - 79 Lambda expression to create a delegate
            //LambdaExpression();

            //Another feature of delegates is that you can combine them together. This is called multicasting.
            //LISTING 1 - 76 A multicast delegate
            //Multicast();
        }

        public static void ManuallyRaisingEventsExceptionHandling()
        {
            CreateAndRaiseEventsExceptionHandling();
        }

        public static void CreateAndRaiseEventsExceptionHandling()
        {
            PubForEventsExceptionHandling p = new PubForEventsExceptionHandling();
            p.OnChange += (sender, e) => Console.WriteLine("Subscriber 1 called");

            p.OnChange += (sender, e) =>
            {
                throw new Exception();
            };

            p.OnChange += (sender, e) => Console.WriteLine("Subscriber 3 called");
            try
            {
                p.Raise();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.InnerExceptions.Count);
            }
        }

        public static void CustomEventAccessor()
        {
            CreateAndRaiseForCustomEventAccessor();
        }

        public static void CreateAndRaiseForCustomEventAccessor()
        {
            PubForCustomEventAccessor p = new PubForCustomEventAccessor();
            p.OnChange += (sender, e) => Console.WriteLine("Event raised: {0}", e.Value);
            p.Raise();
        }

        public static void CustomEventArguments()
        {
            CreateAndRaiseForCustomEventArg();
        }

        public static void CreateAndRaiseForCustomEventArg()
        {
            PubForCustomEventArg p = new PubForCustomEventArg();
            p.OnChange += (sender, e) => Console.WriteLine("Event raised: {0}", e.Value);
            p.Raise();
        }

        public static void ActionToExposeEvent()
        {
            CreateAndRaise();
        }


        public static void CreateAndRaise()
        {
            Pub p = new Pub();
            p.OnChange += () => Console.WriteLine("Event raised to method 1");
            p.OnChange += () => Console.WriteLine("Event raised to method 2");
            p.Raise();
        }
        public static void LambdaExpression()
        {
            var val = "";
            var valid = false;

            while (!valid)
            {
                Console.Write("Enter the first number: ");
                val = Console.ReadLine();
                valid = !string.IsNullOrWhiteSpace(val) &&
                    val.All(c => c >= '0' && c <= '9');

                if (!valid)
                    Console.WriteLine("Please enter a number");
            }
            valid = false;
            int i = int.Parse(val);
            while (!valid)
            {
                Console.Write("Enter the second number: ");
                val = Console.ReadLine();
                valid = !string.IsNullOrWhiteSpace(val) &&
                    val.All(c => c >= '0' && c <= '9');

                if (!valid)
                    Console.WriteLine("Please enter a number");
            }

            int j = int.Parse(val);

            Console.WriteLine("*************************************************");
            Console.WriteLine("Result:");
            CalcLambdaExpression(i, j);

        }

        public static void CalcLambdaExpression(int i, int j)
        {
            Calculation calcAdd = (x, y) => x + y;
            Console.WriteLine($"Addition: " + calcAdd(i, j)); // Displays 7
            Calculation calcSub = (x, y) => x - y;
            Console.WriteLine($"Subtruction: " + calcSub(i, j)); // Displays 1
            Calculation calcMul = (x, y) => x * y;
            Console.WriteLine($"Multiplication: " + calcMul(i, j)); // Displays 12
            Calculation calcDivision = (x, y) => x / y;
            Console.WriteLine($"Division: " + calcDivision(i, j)); // Displays 12
            Calculation calcRemainder = (x, y) => x % y;
            Console.WriteLine($"Remainder: " + calcRemainder(i, j)); // Displays 12
        }

        public static void Multicast()
        {
            Del d = MethodOne;
            d += MethodTwo;
            d();
        }
        public static void MethodOne()
        {
            Console.WriteLine("MethodOne");
        }
        public static void MethodTwo()
        {
            Console.WriteLine("MethodTwo");
        }
    }



}
