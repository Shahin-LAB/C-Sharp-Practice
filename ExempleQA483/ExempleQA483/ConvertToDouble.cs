using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleQA483
{
    public class Common1
    {
        public double ConvertToDouble(string aParam)
        {
            double result;
            if (!double.TryParse(aParam, out result))
            {
                return 0;
            }

            return result;

            //double OutVal;
            //double.TryParse(aParam, out OutVal);

            //if (double.IsNaN(OutVal) || double.IsInfinity(OutVal))
            //{
            //    return 0;
            //}
            //return OutVal;
        }
    }

    public static class Common2
    {
        public static double ConvertToDouble(string Value)
        {
            if (Value == null)
            {
                return 0;
            }
            else
            {
                double OutVal;
                double.TryParse(Value, out OutVal);

                if (double.IsNaN(OutVal) || double.IsInfinity(OutVal))
                {
                    return 0;
                }
                return OutVal;
            }
        }
    }
}
