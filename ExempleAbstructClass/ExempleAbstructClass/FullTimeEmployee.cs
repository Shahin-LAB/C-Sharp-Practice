using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleAbstructClass
{
    public class FullTimeEmployee : BaseEmployee
    {
        
        public int AnnualSalay { get; set; }

        //public override  int GetMonthlySalary()
        //{
        //    return AnnualSalay / 12;
        //}
        public override int GetMonthlySalary()
        {
            return AnnualSalay / 12;
        }

    }


}
