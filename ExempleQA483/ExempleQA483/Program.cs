using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExempleQA483
{
    public class DeptInfo 
    {
        public int Id { get; set;}
        public string Name { get; set;}
        public override string ToString()
        {
            return "ID: " + Id + "   Name: " + Name;
        }
        //public override bool Equals(object obj)
        //{
        //    if (obj == null) return false;
        //    deptInfo objAsPart = obj as deptInfo;
        //    if (objAsPart == null) return false;
        //    else return Equals(objAsPart);
        //}
        //public bool Equals(deptInfo other)
        //{
        //    if (other == null) return false;
        //    return (this.Id.Equals(other.Id));
        //}
    }

    
    public class Program
    {
        
        static void Main()
        {

            //FindDepartment findDepartment = new FindDepartment();
            //findDepartment.findDepartment();

            Console.Write("Enter unit price");
            string price = Console.ReadLine();
            
            
            Regex reg = new Regex(@"^\d+(\.\d\d)$"); //those are correct answer
            if (reg.IsMatch(price))


            //if (Regex.IsMatch(price, @"^(-)?\d+(\.\d\d)$"))-------So that is not the correct answer

                Console.WriteLine("Valid Price");
            else
                Console.WriteLine("Invalid Price");            
        }       



        private bool GetMatch(List<DeptInfo> departments, string searchItem )
        {
            var findDepartment = departments.Exists((delegate (DeptInfo deptName)
             {
                 return deptName.Equals(searchItem);
             }
            ));
            return findDepartment;
        }
    }
}
