using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleAbstructClass
{
    public class ExempleInterface
    {
        public void exempleInterface()
        {
            class1 Ins_class1 = new class1();
            class2 Ins_class2 = new class2();
            //Ins_class2.Method1(); // so always throw exception even in the compile errror, FALSE
            ((INewInterface)Ins_class2).Method1(); // so there is no compile errror but there is run time error, TRUE

            //public void Method1() // implicit implementation of INewInterface, TRUE
            //{
            //    throw new NotImplementedException();
            //}

        }
    }

    public class class1 : class2, INewInterface
    {
        class2 Ins_class2 = new class2();                

    }
    public interface INewInterface
    {
        void Method1();
    }
    public class class2 : INewInterface
    {
        //public void Method1() // implicit implementation of INewInterface
        //{
        //    throw new NotImplementedException();
        //}

        void INewInterface.Method1() // Explicit implementation of INewInterface
        {
            throw new NotImplementedException();
        }
    }

}
