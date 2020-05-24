using System;
using System.CodeDom;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCallWebService
{

    public class CallWebService
    {
        //Constructor, But I never use this
        public CallWebService()
        {

        }

        public string CallAPI()
        {   
            
            string attrVal = "";
            XmlDocument doc = new XmlDocument();
            doc.Load("https://api.met.no/weatherapi/locationforecast/1.9/?lat=60.10&lon=9.58&msl=70");
            XmlNodeList elemList = doc.GetElementsByTagName("temperature");
            
            //Just a test, only one time
            for (int i = 0; i <1; i++)
            {
                attrVal = elemList[i].Attributes["value"].Value;
            }

            return attrVal;
         
        }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var callWebService = new CallWebService();
            var tempServerName = callWebService.CallAPI();
            Assert.AreEqual("5.4", tempServerName);            
        }
    }
}
