using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;

namespace CRMDataMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new CrmServiceClient("AuthType=Office365; Url=https://dikutv.crm4.dynamics.com/main.aspx#315364673;" +
                "UserName=ext.christer.tallberg@dikse.onmicrosoft.com; Password=?Fotboll123?");

            
            //var fetchXml = $@"
            //    <fetch top='50'>
            //      <entity name='contact'>
            //        <link-entity name='cint_mms_mua_membership' from='cint_contact_id' to='contactid' link-type='inner' />
            //      </entity>
            //    </fetch>";

            var fetchXml = $@"
            <fetch top='50'>
              <entity name='contact'>
                <attribute name='ownerid' />
                <attribute name='firstname' />
                <attribute name='cint_soc_sec_no' />
                <attribute name='lastname' />
                <link-entity name='cint_mms_mua_membership' from='cint_contact_id' to='contactid'>
                  <attribute name='cint_incident_id' />
                  <attribute name='cint_end_date' />
                  <attribute name='cint_incident_resolution_type_id' />
                </link-entity>
              </entity>
            </fetch>";

            var query = new FetchExpression(""+ fetchXml + "");
            var entities = service.RetrieveMultiple(query).Entities;
            foreach (var entity in entities)
            {
                Console.WriteLine(entity["firstname"]); 
            };


            //Linq
            var result1 = (from contact in new OrganizationServiceContext(service).CreateQuery("contact")
                          select new
                          {
                              name = contact["contactid"]
                          }).ToList();


            var result2 = (from contact in new OrganizationServiceContext(service).CreateQuery("contact")
                          join cint_mms_mua_membership in new OrganizationServiceContext(service).CreateQuery("cint_mms_mua_membership")
                          on contact["contactid"] equals cint_mms_mua_membership["cint_contact_id"]
                          select new
                          {
                              name = contact["contactid"],
                              contactName = cint_mms_mua_membership["cint_contact_id"]                              
                              
                          }).ToList();

        }
    }
}
