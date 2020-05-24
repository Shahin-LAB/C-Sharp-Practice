using System;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using VaildEmailAndPassword;


namespace UnitTestVaildEmailAndPassword
{
    public class EmailValidation
    {        

        public bool IsValidEmail(string strEmail)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(strEmail, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }        
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var emailValidation = new EmailValidation();
            var IsValidEmail1 = emailValidation.IsValidEmail("shahin.rohman@hotmail.com");
            Assert.AreEqual(true,IsValidEmail1);           
        }

        [TestMethod]
        public void TestMethod2()
        {
            var emailValidation = new EmailValidation();            
            var IsValidEmail2 = emailValidation.IsValidEmail("shahinrohman£hotmail.com");
            Assert.AreEqual(false, IsValidEmail2);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var emailValidation = new EmailValidation();
            var IsValidEmail3 = emailValidation.IsValidEmail("!shahinrohmanhotmail.com");
            Assert.AreEqual(false, IsValidEmail3);
        }
    }
}
