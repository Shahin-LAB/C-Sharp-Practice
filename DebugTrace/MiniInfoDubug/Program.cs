#define DEBUG

////To minimize the amount of information contained within the debug symbols that are shipped
////Trace is enabled
//#undef DEBUG
//#define TRACE


////Debug is enabled
////#define DEBUG
//////#define TRACE  
////#undef TRACE


using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInfoDubug
{
    public class TestClass
    {
        [Conditional("DEBUG")]
        public void LogData()
        {
            Trace.Write("Logdata1");
        }
        public void RunTestClass()
        {
            this.LogData();
#if (DEBUG)
            Trace.Write("Logdata2");
#endif
        }
    }
    public class Program
    {
        public static void Main()
        {
            //To check when you will run RunTestClass()
            TestClass testClass = new TestClass();
            testClass.RunTestClass();

            //To check which one is enable (Debug or Release)

            //TestDefine testDefine = new TestDefine();
            //testDefine.testDefine();


        }
    }

    public class TestDefine
    {
        public void testDefine()
        {
            #if (DEBUG)
                                        Console.WriteLine("Debugging is enabled.");
            #endif

            #if (TRACE)
                        Console.WriteLine("Tracing is enabled.");
            #endif
        }
    }
    // Output:  
    // Debugging is enabled.  
}
