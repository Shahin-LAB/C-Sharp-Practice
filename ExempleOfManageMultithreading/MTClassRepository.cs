
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExempleOfManageMultithreading
{
    public class MTClassRepository
    {
        public void AccessShareDataMTAMethod()
        {
            int n = 0;
            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    n++;
                }

            });
            for (int i = 0; i < 1000000; i++)
            {
                n--;
            }
            up.Wait();
            Console.WriteLine(n);

            //The seemingly simple operation of incrementing and decrementing the variable n results 
            //in both a lookup(check the value of n) and add or subtract 1 from n.
            //But what if the first task reads the value and adds 1, 
            //and at the exact same time task 2 reads the value and subtracts 1 ? 
            //This is what happens in this example and that’s why you never get the expected output of 0.
        }

        public void AccessShareDataWithLockMTAMethod()
        {
            int n = 0;
            object _lock = new object();
            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++) lock (_lock)
                    {
                        n++;
                    }

            });
            for (int i = 0; i < 1000000; i++) lock (_lock)
                {
                    n--;
                }
            up.Wait();
            Console.WriteLine(n);

            //After this change, the program always outputs 0 because access to the variable n is now synchronized
        }

        public void UseCancellationTokenMTAMethod()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;
            Task task = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }
                throw new OperationCanceledException();
            }, token).ContinueWith((t) =>
            {
                t.Exception.Handle((e) => true);
                Console.WriteLine("You have cancled the task");
            }, TaskContinuationOptions.OnlyOnCanceled);

            Console.WriteLine("Press enter to stop the task");
            Console.ReadLine();
            cancellationTokenSource.Cancel();
            Console.WriteLine("Press enter to end the application");
            Console.ReadLine();
        }

        public void CreateDeadlockMTAMethod()
        {
            object lockA = new object();
            object lockB = new object();

            var up = Task.Run(() =>
            {
                lock (lockA)
                {
                    Thread.Sleep(1000);
                    lock (lockB)
                    {
                        Console.WriteLine("Loacked A and B");
                    }

                }

            });

            lock (lockB)
            {
                lock (lockA)
                {
                    Console.WriteLine("Locked B and A");
                }
            }
            up.Wait();
        }
    }
}
