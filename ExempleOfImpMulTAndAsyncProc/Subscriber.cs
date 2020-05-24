using System;
using System.Collections.Generic;
using System.Text;

namespace ExempleOfImpMulTAndAsyncProc
{
    public class Alert
    {
        public event EventHandler<EventArgs> SendMessage;

        public void Execute()
        {
            SendMessage(this, new EventArgs() );
        }
    }
    public class Subscriber
    {
        Alert alert = new Alert();
        public void Subscribe()
        {
            alert.SendMessage += (sender, e) => { Console.WriteLine("First"); };
            alert.SendMessage += (sender, e) => { Console.WriteLine("Second"); };
            alert.SendMessage += (sender, e) => { Console.WriteLine("Third"); };
            alert.SendMessage += (sender, e) => { Console.WriteLine("Third"); };
        }
        public void Execute()
        {
            alert.Execute();
        }
    }

    
}
