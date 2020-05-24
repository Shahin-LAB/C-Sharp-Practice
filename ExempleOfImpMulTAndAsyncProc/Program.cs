using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ExempleOfImpMulTAndAsyncProc
{
    public static class Program
    {
        const int numberOfIterations =5;
        //int characterCount = 0;

        [ThreadStatic]
        public static int _field;

        public static ThreadLocal<int> _filed =
            new ThreadLocal<int>(() =>
            {
                return Thread.CurrentThread.ManagedThreadId;
            });

        static void Main()
        {           
            //while(true)
            //{
                try
                {
                    //listing 1-1 creating a thread with the thread class
                    //createthreadmethod();

                    //LISTING 1 - 2 Using a background thread
                    //CreateBackAndForegroundThreadMethod();

                    //LISTING 1 - 3 Using the ParameterizedThreadStart
                    //CreateParameterizedThreadStartMethod();

                    //LISTING 1 - 4 Stopping a thread
                    //CreateStoppedThreadMethod();

                    //A thread can also have its own data that’s not a local variable.By marking a field with the ThreadStatic attribute
                    //LISTING 1-5 Using the ThreadStaticAttribute            
                    //CreateThreadStaticAttribute();

                    //If you want to use local data in a thread and initialize it for each thread, you can use the ThreadLocal < T > class
                    //LISTING 1-6 Using ThreadLocal<T>
                    //CreateThreadLocalMethod();


                    //Thread pools
                    //A thread pool is created to reuse those threads
                    //LISTING 1-7 Queuing some work to the thread pool
                    //QueuingSomeWorkThreadPool();

                    //The concept of a Task, which is an object that represents some work that should be done.
                    //Listing 1-8 shows how to start a new Task and wait until it’s finished
                    //StartNewTastUntilFinished();

                    //.NET Framework also has the Task<T> class that you can use if a Task should return a value.
                    //LISTING 1-9 Using a Task that returns a value
                    //TaskThatReturnValue();

                    //The ContinueWith method has a couple of overloads that you can use to configure when the continuation will run
                    //LISTING 1 - 10 Adding a continuation
                    //TaskThatReturnValueWithContinuation();


                    //LISTING 1 - 11 Scheduling different continuation tasks
                    //SchedulingContinuationTask();

                    //LISTING 1-12 Attaching child tasks to a parent task
                    //AttachChildTaskToParentTask();

                    //LISTING 1 - 14 Using Task.WaitAll
                    //UseStopWatch();

                    //Stopwatch sw = new Stopwatch();
                    //sw.Start();
                    //Task t = MainAsync();
                    //t.Wait();
                    //sw.Stop();
                    //Console.WriteLine(sw.Elapsed);

                    //CallGetStocks();
                    //UseTaskWaitAll();

                    //LISTING 1 - 15 Using Task.WaitAny
                    //UseTaskWaitAny();

           

                    //CheckSendMessage alert
                    //CheckSendMessagealert();

                    //Test

                    //int c = 3, d = 4, e = 5;
                    //Console.WriteLine(--c * d - ++e);

                                        
                    

                    //CkWithClassifer();

                    //Console.WriteLine("First Value : ");
                    //string S1 = Console.ReadLine().ToString();
                    //Console.WriteLine("Second Value : ");
                    //string S2 = Console.ReadLine().ToString();
                    //int a = int.Parse(S1);                
                    //int b = int.Parse(S2);
                    
                    //Console.WriteLine("Result :{0}", a+b);
                    //Console.WriteLine($"Result :{a + b}");
                    //break;


                }
                //catch(ArgumentNullException)
                //{
                //    Console.WriteLine("You need enter a value.");
                //    //throw;
                //}
                //catch (FormatException)
                //{
                //    Console.WriteLine("You need enter a valid number.");
                //    //throw;
                //}
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString ());
                    //Log(ex);
                    //throw;

                    //LOG IT!!!
                    
                    //throw; //can rethrow the error to allow it to bubble up, or not, and ignore it.

                    string filePath = @"C:\Shahin\ErrorLog.txt";

                    //Exception ex = ...
                    if (!File.Exists(filePath))
                    {
                        File.Create(filePath).Dispose();
                    }

                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine("=============Error Logging ===========");
                        writer.WriteLine("===========Start============= " + "Date : " + DateTime.Now.ToString());
                        writer.WriteLine();

                        while (ex != null)
                        {
                            writer.WriteLine(ex.GetType().FullName);
                            writer.WriteLine("Error Message : " + ex.Message);
                            writer.WriteLine("StackTrace : " + ex.StackTrace);
                            
                            ex = ex.InnerException;
                            //writer.WriteLine("InnerException : " + ex.InnerException?.Message);
                        }
                        writer.WriteLine("===========End============= " + "Date : " + DateTime.Now.ToString());
                    }
                }
                finally
                {
                    Console.WriteLine("Program complete.");                    
                }
            //}
        }

        public static void CkWithClassifer()
        {
            Console.WriteLine("Enter a number :");
            int input = int.Parse(Console.ReadLine().ToString());

            if (input>0)
            {
                Console.WriteLine("Positiv");
            }
            else
            {
                Console.WriteLine("Negativ");
            }

            var classify = input > 0 ? "Positiv" : "Negative";
            //var classify = input > 0 : "Positiv" : "Negative";


            Console.WriteLine(classify);

        }

        

        public static void CheckSendMessagealert()
        {
            Subscriber subscriber = new Subscriber();
            subscriber.Subscribe();
            subscriber.Execute();
        }

        

        

        static async Task MainAsync()
        {
            //await Task.Delay(10000);
            await UseTaskForCountingData();
            
            //await UseStopWatch();

        }

        public static void CallGetStocks()
        {
            try
            {
                UseStopWatch();
                //var cd= new calldata();

            }
            catch (Exception ex)
            {
                var error = ex.Message;
                Console.WriteLine(error);
                //Notes.text += ex.Message;

            }

        }
        public static int CountCharacters()
        {
            int count = 0;

            using (StreamReader reader= new StreamReader ("C:\\CompanyData.txt"))
            {
                string content = reader.ReadToEnd();
                count = content.Length;
                Thread.Sleep(5000);
            }
            return count;
        }

        

        public static void UseThreadForCountingData()
        {
            Thread th= new Thread (() =>
            {
                int characterCount = CountCharacters();
                Action action = (() => 
                {
                    Console.WriteLine("Processing is going on..");
                    
                });
                //action.BeginInvoke();
                //var asyncResult1 = action.BeginInvoke(null, null);
                //asyncResult1.AsyncWaitHandle.WaitOne();
            });
            th.Start();
            th.Join();
        }
        public static async Task UseTaskForCountingData()
        {
            Task<int> task = new Task<int>(CountCharacters);
            task.Start();
            Console.WriteLine("Processing is going on...");
            int count = await task;
            Console.WriteLine(count.ToString());
        }
        public static void UseTaskWaitAny()
        {
            Task<int>[] tasks = new Task<int>[3];
            
            tasks[0] = Task.Run(() => { Thread.Sleep(1000); return 1; });
            tasks[1] = Task.Run(() => { Thread.Sleep(2000); return 2; });
            tasks[2] = Task.Run(() => { Thread.Sleep(3000); return 3; });
            while (tasks.Length > 0)
            {
                int i = Task.WaitAny(tasks);
                Task<int> completedTask = tasks[i];
                Console.WriteLine(completedTask.Result);
                var temp = tasks.ToList();
                temp.RemoveAt(i);
                tasks =temp.ToArray();
                
            }

            
        }

        public static void UseStopWatch()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Algorithm1();            
            sw.Stop();
            Console.WriteLine(sw.Elapsed );

            sw.Reset();
            sw.Start();
            Algorithm2();
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            sw.Reset();
            sw.Start();
            Algorithm3();
            sw.Stop();
            Console.WriteLine(sw.Elapsed);


            Console.WriteLine("Ready...");
            Console.ReadLine();

        }

        public static void Algorithm3()
        {
            StringBuilder sb = new StringBuilder();
            Parallel.For(0, numberOfIterations, i =>
            {
                //Thread.Sleep(1000);
                //UseTaskWaitAny();
                //UseTaskWaitAny();

                Task t = MainAsync();
                t.Wait();

                //UseThreadForCountingData();

            });
            
            string result = sb.ToString();
        }

        public static void Algorithm2()
        {
            //string result = "";
            for (int i = 0; i < numberOfIterations; i++)
            {
                //result += "1";
                //UseTaskWaitAll();
                //UseTaskWaitAny();
                //UseTaskWaitAny();

                Task t = MainAsync();
                t.Wait();

                //UseThreadForCountingData();


            }

        }

        public static void Algorithm1()
        {
            StringBuilder sb = new StringBuilder();            

            for (int i=0; i<numberOfIterations;i++ )
            {
                //sb.Append('1');
                //UseTaskWaitAll();
                //UseTaskWaitAny();

                Task t = MainAsync();
                t.Wait();

                //UseThreadForCountingData();


            }
            string result = sb.ToString();
        }

        public static void UseTaskWaitAll()
        {
            Task[] tasks = new Task[3];
            tasks[0] = Task.Run(() => 
            {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });
            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("2");
                return 2;
            });
            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("3");
                return 3;
            });
            Task.WaitAll(tasks); 
            //Task.WaitAny(tasks);            
            //Task.WhenAll(tasks);            
        }

        public static void AttachChildTaskToParentTask()
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];
                new Task(() => results[0] = 0,
                TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = 1,
                TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = 2,
                TaskCreationOptions.AttachedToParent).Start();
                return results;
            });
            var finalTask = parent.ContinueWith(
            parentTask => {
                foreach (int i in parentTask.Result)
                    Console.WriteLine(i);
            });
            finalTask.Wait();
            
        }

        public static void SchedulingContinuationTask()
        {
            Task<int> t = Task.Run(() =>
            {
                //Thread.Sleep(1000);
                return 42;                
            });

            t.ContinueWith((i) =>
            {
                Console.WriteLine("Cancled");                
            },TaskContinuationOptions.OnlyOnCanceled);

            t.ContinueWith((i) =>
            {
                Console.WriteLine("Faluted");
            },TaskContinuationOptions.OnlyOnFaulted);

            var completeTask = t.ContinueWith((i) => 
                                {
                                    Console.WriteLine("Completed");
                                },TaskContinuationOptions.OnlyOnRanToCompletion);

            completeTask.Wait(); 
        }

        public static void TaskThatReturnValueWithContinuation()
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;

            }).ContinueWith ((i) =>
            {
                return i.Result * 2; 
            });
            Console.WriteLine($"The task return the value with continuation operation : {t.Result}");
        }

        public static void TaskThatReturnValue()
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            });
            Console.WriteLine($"The task return the value : {t.Result}");
        }

        public static void StartNewTastUntilFinished()
        {   
            Task t = Task.Run(() =>
            {
                for (int x = 0; x < 5; x++)
                {
                    Console.WriteLine("*");
                }
            });
            t.Wait();                
        }

        public static void QueuingSomeWorkThreadPool()
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine("Working on a thread from threadpool");
            });
            Console.ReadLine();
        }

        public static void createthreadmethod()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.Start();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread: Do some work");
                Thread.Sleep(0);
                //Console.ReadKey(); 
            }
            //Thread.Join method is called on the main thread to let it wait until the other thread finishes
            t.Join();
        }

        public static void CreateThreadLocalMethod()
        {

            new Thread(() =>
            {
                for (int i = 0; i < _filed.Value; i++)
                {
                    Console.WriteLine("Thread A: {0}", i);
                }
            }).Start();
            new Thread(() =>
            {
                for (int i = 0; i < _filed.Value; i++)
                {
                    Console.WriteLine("Thread B: {0}", i);
                }
            }).Start();
            Console.ReadKey();
        }

        public static void CreateThreadStaticAttribute()
        {
            //With the ThreadStaticAttribute applied, the maximum value of _field becomes 10.If you remove it, 
            //you can see that both threads access the same value and it becomes 20.

            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _field++;
                    Console.WriteLine("Thread A: {0}", _field);
                }
            }).Start();
            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _field++;
                    Console.WriteLine("Thread B: {0}", _field);
                }
            }).Start();
            Console.ReadKey();
        }

        public static void CreateStoppedThreadMethod()
        {
            bool stopped = false;
            Thread t = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Running...");
                    Thread.Sleep(1000);
                }
            }));
            t.Start();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            stopped = true;
            t.Join();
        }

        public static void CreateParameterizedThreadStartMethod()
        {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod2));
            //In this case, the value 5 is passed to the ThreadMethod as an object.You can cast it to the expected type to use it in your method.
            t.Start(5);
            t.Join();
        }

        public static void CreateBackAndForegroundThreadMethod()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));

            //If you run this application with the IsBackground property set to true, the application exits immediately.
            t.IsBackground = true;


            //If you set it to false (creating a foreground thread), the application prints the ThreadProc message ten times.            
            //t.IsBackground = false;

            t.Start();
        }

        

        public static void ThreadMethod2(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);
            }
        }
        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Thread Proc :{0}", i);
                Thread.Sleep(1000);
            }
        }
    }
}


