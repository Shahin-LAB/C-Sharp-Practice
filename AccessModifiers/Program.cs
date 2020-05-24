using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    public class Customer
    {
        private int _id;
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
    }

    public class CustomerProtected
    {
        protected int _id;
    }

    public class CorporateCustomer : Customer
    {
        public void PrintID()
        {
            CorporateCustomer CC = new CorporateCustomer();
            CC.ID = 101; // ID accessibale because of it drived from the customer class

            base.ID = 102; //accessiable
            this.ID = 103;//accessiable
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // there are 5 different access modifiers in C#

            // 1. Private
            // 2. Protectd
            // 3. Internal
            // 4. Protected Internal
            // 5. Public

            Customer C1 = new Customer();
            // 1. Private                    
            //Console.WriteLine(C1._id); //Inaccessable due to protection level(Private)
            Console.WriteLine(C1.ID); //Accessable due to public level

            CustomerProtected CP1 = new CustomerProtected();
            //Console.WriteLine(CP1.ID); //Inaccessable due to protectd level(protection)
        }
    }
}
