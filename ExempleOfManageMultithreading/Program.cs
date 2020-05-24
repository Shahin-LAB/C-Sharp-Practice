
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static ManageMultithreading.MTClassRepository;


namespace ExempleOfManageMultithreading
{
    class Program
    {
        static void Main()
        {


            MTClassRepository mTClassRepository = new MTClassRepository();

            //Synchronizing resources
            //LISTING 1 - 35 Accessing shared data in a multithreaded application

            Console.WriteLine("*****Accessing shared data in a multithreaded application********");
            mTClassRepository.AccessShareDataMTAMethod();



            //It’s important to synchronize access to shared data.
            //LISTING 1 - 36 Using the lock keyword

            //Console.WriteLine("*****Using the lock keyword********");
            //mTClassRepository.AccessShareDataWithLockMTAMethod();

            //LISTING 1-37 Creating a deadlock
            //deadlock, where both threads wait on each other, causing neither to ever complete.
            //Console.WriteLine("*****Creating a deadlock********");
            //mTClassRepository.CreateDeadlockMTAMethod();

            //LISTING 1 - 42 Using a CancellationToken
            //When working with multithreaded code such as the TPL, the Parallel class, or PLINQ, you often have long-running tasks.
            //The .NET Framework offers a special class that can help you in canceling these tasks: CancellationToken.

            Console.WriteLine("*****Using a CancellationToken********");
            mTClassRepository.UseCancellationTokenMTAMethod();




        }


    }
}
