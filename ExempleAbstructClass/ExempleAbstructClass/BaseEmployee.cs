using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleAbstructClass
{
    public abstract class BaseEmployee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // If we want to add MiddleName property to here then it will be accessed to FullTimeEmployee or ContractEmployee class as well
        // So the code maintain is easy

        public string GetfullName()
        {
            return FirstName + " " + LastName;
        }

        public abstract int GetMonthlySalary();

        //Make it Virtual because of the BaseEmployee Class does not know how to provide implementaion of FullTimeEmployee or ContractEmployee Class.
        // the drived class (FullTimeEmployee or ContractEmployee) is the responsibility is to do that.

        //public virtual int GetMonthlySalary()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
