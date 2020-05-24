using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleAbstructClass
{
    public class ContractEmployee :BaseEmployee 
    {   
        public int HourlyPay { get; set; }
        public int TotalHoursWorked { get; set; }

        //public override int GetMonthlySalary()
        //{
        //    return TotalHoursWorked * HourlyPay;
        //}

        public override int GetMonthlySalary()
        {
            return TotalHoursWorked * HourlyPay;
        }
    }
}
