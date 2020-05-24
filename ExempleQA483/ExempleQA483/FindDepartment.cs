using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleQA483
{
    public class FindDepartment
    {
        public void  findDepartment()
        {



            List<string>  dept = new List<string>();

            dept.Add("Accounting");
            dept.Add("Sales");
            dept.Add("IT");
            dept.Add("Admin");
            dept.Add("Economy");

            Console.WriteLine("Show the Existing Department :");

            foreach (var deptItem in dept)
            {
                Console.WriteLine(deptItem);
            }

            Console.WriteLine();
            //SEARCH ITEM

            // Check if an department = DSV exists.

            Console.WriteLine("\nSEARCH = DSV with delagate ? : {0}",
                dept.Exists((delegate (string DeptName)
                {
                    return DeptName.Equals("DSV");
                    //return DeptName.Find("ABC");
                }
            )));
            //Return False


            //Replace the delegate with lamda expression, which one is correct

            // Find items where name contains "DSV".
            Console.WriteLine("\nSEARCH = DSV with lambda ? : {0}",
                dept.Where(x => x == "DSV"));
            //Error

            Console.WriteLine("\nSEARCH = DSV with lambda ? : {0}",
                dept.Where(x => x.Equals("DSV")));
            //Error

            //Console.WriteLine("\nSEARCH = DSV with lambda ? : {0}",
            //    dept.First(x => x == "DSV"));
            //this will make compile error


            Console.WriteLine("\nSEARCH = DSV with lambda ? : {0}",
                dept.Exists(x => x == "DSV"));
            //Return False--- SO this the corrct answer.

            //
            Console.WriteLine("------------------------------------");

            //Now we are looking for en existing department like IT

            //IF search item is =IT

            Console.WriteLine("\nSEARCH = IT with delegate ? : {0}",
                dept.Exists((delegate (string DeptName)
                {
                    return DeptName.Equals("IT");
                    //return DeptName.Find("ABC");
                }
            )));
            //Return True

            //With lambda
            Console.WriteLine("\nSEARCH = IT with lambda ? : {0}",
                dept.Where(x => x == "IT"));
            //Error
            Console.WriteLine("\nSEARCH = IT with lambda ? : {0}",
                dept.Where(x => x.Equals("IT")));
            //Error
            Console.WriteLine("\nSEARCH = IT with lambda ? : {0}",
                dept.First(x => x == "IT"));

            //Return IT

            Console.WriteLine("\nSEARCH = IT with lambda ? : {0}",
                dept.Exists(x => x == "IT"));

            //Return True--- SO this is the correct replacement with delegate <--> lambda
            Console.WriteLine();

            Console.WriteLine("-----------------------------------");

            var departments = new List<DeptInfo>();

            departments.Add(new DeptInfo { Id = 1, Name = "Accounting" });
            departments.Add(new DeptInfo { Id = 2, Name = "Sales" });
            departments.Add(new DeptInfo { Id = 3, Name = "IT" });
            departments.Add(new DeptInfo { Id = 9, Name = "Admin" });
            departments.Add(new DeptInfo { Id = 20, Name = "Economy" });

            Console.WriteLine("Show the Existing Department :");
            foreach (var department in departments)
            {
                Console.WriteLine($"{department.Id,-20}: {department.Name,10}");
            }

            DeptInfo deptInfofin = new DeptInfo { Id = 10, Name = "finance" };
            int lessthenIndex = departments.FindIndex(i => i.Id > 10);
            //int gaterthenIndex = departments.FindIndex(i => i.Id > 6 && i.Id < 6);
            departments.Insert(lessthenIndex, deptInfofin);

            Console.WriteLine("Add finance department where index > 20 :");
            foreach (var department in departments)
            {
                Console.WriteLine($"{department.Id,-20}: {department.Name,10}");
            }

            Console.WriteLine("-----------------------------------");

            //SEARCH ITEM

            // Check if an department = DSV exists.

            Console.WriteLine("\nSEARCH = DSV with delegate ? : {0}",
                departments.Exists((delegate (DeptInfo DeptName)
                {
                    return DeptName.Equals("DSV");
                    //return DeptName.Find("ABC");
                }
            )));

            //Replace the delegate with lamda expression, which one is correct

            // Find items where name contains "DSV".
            Console.WriteLine("\nSEARCH = DSV with lambda ? : {0}",
                departments.Where(x => x.Name == "DSV"));
            //Error
            Console.WriteLine("\nSEARCH = DSV with lambda ? : {0}",
                departments.Where(x => x.Name.Equals ("DSV")));
            //Error

            //Console.WriteLine("\nCheck if an department SEARCH ITEM = DSV exists ? : Depertment = DSV, with Lambda : {0}",
            //    departments.First(x => x.Name == "DSV"));

            //Make compile Error

            Console.WriteLine("\nSEARCH = DSV with lambda ? : {0}",
                departments.Exists (x => x.Name == "DSV"));

            //Return : False : SO this is the correct answer.

            // Find items where name contains "IT".

            Console.WriteLine("\nSEARCH = IT with lambda ? : {0}",
                departments.Find(x => x.Name.Contains("IT")));

            // Check if an department = IT exists.
            Console.WriteLine("\nSEARCH = IT with lambda ? : {0}",
                departments.Exists(x => x.Equals("IT")));

            //I create a simple search criteria
            //string personToBeSearched = "mario";
            //person mario = agenda.Find(delegate (person p) { return p.Nome == personToBeSearched; });


            // Check if an department = IT with Id 1 exists.
            Console.WriteLine("\nSEARCH = IT with lambda ? : {0}",
                departments.Exists(x => x.Name == "IT"));




            Console.WriteLine("************Another exemple*********");

            List<string> myData = new List<string>();
            myData.Add("Accounting");
            myData.Add("Sales");
            myData.Add("IT");

            Console.WriteLine("Remove all item from myData list");

            //for (int i = 0; i < myData.Count; i++)
            //    myData.RemoveAt(i);
            //------This is not the correct answer

            while (myData.Count != 0)
                myData.RemoveAt(0);
            //OR
            myData.Clear();
            // Those are the correct answer



            //foreach (string currentString in myData) myData.Remove(currentString);------This is not the correct answer

            //for (int i = 0; i <= myData.Count; i++)
            //    myData.RemoveAt(0); -----------This is not the correct answer


            foreach (var item in myData)
            {
                Console.WriteLine($"{myData}");
            }

        }

    }
}
