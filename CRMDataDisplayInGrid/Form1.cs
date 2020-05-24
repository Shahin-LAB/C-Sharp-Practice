using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;

namespace CRMDataDisplayInGrid
{
    public partial class Frm_DataManagement : Form
    {
        public Frm_DataManagement()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            var service = new CrmServiceClient("AuthType=Office365; Url=https://dikutv.crm4.dynamics.com/main.aspx#315364673;" +
                "UserName=ext.christer.tallberg@dikse.onmicrosoft.com; Password=?Fotboll123?");



            //dataGridView1.DataSource = (from contact in new OrganizationServiceContext(service).CreateQuery("contact")
            //                             select new
            //                             {
            //                                 name = contact["contactid"]
            //                             }).ToList();
            //dataGridView1.data



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

            var fetchXmlaccount = $@"
            <fetch top='50'>
              <entity name='account' />
            </fetch>";
            

            var fetchXmlJoin = $@"
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

            var query = new FetchExpression("" + fetchXmlJoin + "");
            var entities = service.RetrieveMultiple(query).Entities;
            foreach (var entity in entities)
            {
                Console.WriteLine(entity["firstname"]);
            };

                        
            EntityCollection retAccounts = service.RetrieveMultiple(new FetchExpression(fetchXmlaccount));
            if (retAccounts.Entities.Count > 0)
            {
                DataSet contactData = new DataSet();
                DataTable dt = new DataTable();

                dt.Columns.Add("ownerid");
                dt.Columns.Add("name");
                //dt.Columns.Add("cint_soc_sec_no");
                //dt.Columns.Add("cint_incident_id");

                foreach (var account in retAccounts.Entities)
                {
                    DataRow dr = dt.NewRow();
                    dr["ownerid"] = account["ownerid"].ToString();
                    dr["name"] = account["name"].ToString();
                    //dr["cint_soc_sec_no"] = contact["cint_soc_sec_no"].ToString();

                    dt.Rows.Add(dr);
                }

                //dataGridView1.Tables.Add(dt);
                dGV_DataContent.DataSource = dt;
                //dataGridView1.Databind();

                //dt.Fill(ds);
                //dataGridView1.DataSource = ds.Tables["Student"].DefaultView;
            }



            //var result2 = (from contact in new OrganizationServiceContext(service).CreateQuery("contact")
            //               join cint_mms_mua_membership in new OrganizationServiceContext(service).CreateQuery("cint_mms_mua_membership")
            //               on contact["contactid"] equals cint_mms_mua_membership["cint_contact_id"]
            //               select new
            //               {
            //                   name = contact["contactid"],
            //                   SOC= contact["cint_soc_sec_no"].ToString(),
            //                   contactName = cint_mms_mua_membership["cint_name"],
            //                   membership_type_id = cint_mms_mua_membership["cint_mms_mua_membership_type_id"]

            //               }).ToList();

            //dGV_DataContent.DataSource = result2 ;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var service = new CrmServiceClient("AuthType=Office365; Url=https://dikutv.crm4.dynamics.com/main.aspx#315364673;" +
                "UserName=ext.christer.tallberg@dikse.onmicrosoft.com; Password=?Fotboll123?");


            RetrieveAllEntitiesRequest retrieveAllEntityRequest = new RetrieveAllEntitiesRequest
            {
                RetrieveAsIfPublished = true,
                EntityFilters = EntityFilters.Attributes,

            };
            RetrieveAllEntitiesResponse retrieveAllEntityResponse = (RetrieveAllEntitiesResponse)service.Execute(retrieveAllEntityRequest);
            var entities1 = retrieveAllEntityResponse.EntityMetadata;

            DataTable dt1 = new DataTable();
            dt1.Columns.Add("LogicalName");

            foreach (EntityMetadata Entity in entities1)
            {
                DataRow dr1 = dt1.NewRow();
                dr1["LogicalName"] = Entity.LogicalName.ToString();
                dt1.Rows.Add(dr1);
            }
            dataGridView2.DataSource = dt1;
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            if (rB_AttributeName.Checked ==true)
            {
                var service = new CrmServiceClient("AuthType=Office365; Url=https://dikutv.crm4.dynamics.com/main.aspx#315364673;" +
                "UserName=ext.christer.tallberg@dikse.onmicrosoft.com; Password=?Fotboll123?");

                //var item1 = ((System.Windows.Forms.DataGridViewTextBoxEditingControl)dataGridView2.EditingControl).EditingControlFormattedValue;

                var item = dataGridView2.CurrentCell.EditedFormattedValue;
                //var result2 = (from it in new OrganizationServiceContext(service).CreateQuery(""+ item + "")                           
                //               select new {}).ToList();

                //dataGridView1.DataSource = result2;


                var fetchXmlaccount = $@"
                    <fetch top='50'>
                      <entity name='cint_mms_mua_salary'/>
                    </fetch>";

                EntityCollection retAccounts = service.RetrieveMultiple(new FetchExpression(fetchXmlaccount));


                RetrieveEntityRequest retrieveEntityRequest = new RetrieveEntityRequest
                {
                    RetrieveAsIfPublished = true,
                    LogicalName = "" + item + "",
                    EntityFilters = EntityFilters.All

                };
                //RetrieveEntityRequest retrieveEntityResponse = (RetrieveEntityRequest)service.Execute(retrieveEntityRequest);
                var response = ((RetrieveEntityResponse)service.Execute(retrieveEntityRequest));
                var resentities1 = response.EntityMetadata;

                DataTable dt1 = new DataTable();

                dt1.Columns.Add("LogicalName");

                foreach (AttributeMetadata allattributes in resentities1.Attributes)
                {
                    DataRow dr1 = dt1.NewRow();
                    dr1["LogicalName"] = allattributes.LogicalName.ToString();
                    dt1.Rows.Add(dr1);
                }
                dGV_DataContent.DataSource = dt1;

                //var query = new FetchExpression("" + fetchXmlaccount + "");
                //var entities = retAccounts.Entities;


                //var entities1 = entities;


                //DataTable dt1 = new DataTable();

                //dt1.Columns.Add("LogicalName");

                //foreach (EntityMetadata Entity in entities1)
                //{
                //    DataRow dr1 = dt1.NewRow();
                //    dr1["LogicalName"] = Entity.LogicalName.ToString();

                //    dt1.Rows.Add(dr1);
                //}
                //dataGridView2.DataSource = dt1;

                //dataGridView1.DataSource = entities;
                //foreach (var entity in entities)
                //{
                //    Console.WriteLine(entity["firstname"]);
                //};

            }

            if (rb_Data.Checked == true)
            {
                dGV_DataContent.DataSource = null;

                var service = new CrmServiceClient("AuthType=Office365; Url=https://dikutv.crm4.dynamics.com/main.aspx#315364673;" +
                "UserName=ext.christer.tallberg@dikse.onmicrosoft.com; Password=?Fotboll123?");              

                var item = dataGridView2.CurrentCell.EditedFormattedValue;

                //var result2 = (from it in new OrganizationServiceContext(service).CreateQuery(""+ item + "")
                //               select new {}).ToList();               


                //var fetchXmlaccount = $@"
                //    <fetch top='50'>
                //      <entity name='cint_mms_mua_salary'/>
                //    </fetch>";

                string str1 = "<fetch><entity name='";
                string str2 = ""+ item +"";
                string str3 = "'/></fetch>";
                string allstr = str1 + str2 + str3;

                EntityCollection retItems = service.RetrieveMultiple(new FetchExpression(allstr));

                DataTable dtCol = new DataTable();
                DataRow dr = dtCol.NewRow();

                var colNr = 0;
                var rowNr = 0;
                var c = 0;

                //foreach (Entity entity in retItems.Entities)
                //{
                //    foreach (var val in entity.Attributes)
                //    {
                //        dtCol.Columns.Add("" + val.Key + "");
                //        if (rowNr == 0)
                //        {
                //            DataRow dr1 = dtCol.NewRow();
                //            dr["" + val.Key + ""] = val.Value;
                //            dtCol.Rows.Add(dr["" + val.Key + ""].ToString());
                //            rowNr = rowNr + 1;
                //        }
                //        else
                //        {
                //            var r = dtCol.Rows.Count;
                //            c = c + 1;                            
                //            dtCol.Rows[r - 1][c] = val.Value;
                //        }
                //    }

                //}



                foreach (Entity entity in retItems.Entities)
                {

                    //var co = retItems.Entities.Count;
                    if (colNr == 0)
                    {
                        //var t = entity.KeyAttributes.keys;

                        foreach (var val in entity.Attributes)
                        {
                            dtCol.Columns.Add("" + val.Key + "");
                            //dtCol.Rows.Add(dr["" + val.Value  + ""].ToString());

                            if (rowNr == 0)
                            {
                                //for (int x = 0; x < 3; x++)
                                //{
                                //    dr["" + val.Key + ""] = val.Value;
                                //    dtCol.Rows.Add(dr["" + val.Key + ""].ToString());
                                //}                                

                                DataRow dr1 = dtCol.NewRow();
                                dr1["" + val.Key + ""] = val.Value;
                                dtCol.Rows.Add(dr1["" + val.Key + ""].ToString());

                                rowNr = rowNr + 1;
                            }
                            else
                            {
                                //dr["" + val.Key + ""] = val.Value;
                                //dtCol.Rows.Add(dr["" + val.Key + ""].ToString());
                                

                                var r = dtCol.Rows.Count;
                                c = c+1;
                                //dtCol.Rows[0]["" + val.Key + ""] = val.Value;
                                dtCol.Rows[r-1][c] = val.Value;
                                

                                //for (int i = 0; i < 3; i++)
                                //{
                                //    for (int j = 0; j < 18; j++)
                                //    {
                                //        dtCol.Rows[i]["" + val.Key + ""] = val.Value;
                                //        dtCol.Rows[i][j] = val.Value;
                                //    }
                                //}
                                //dtCol.Rows[0].Cells[6].Value = "test";
                            }

                        }


                        //foreach (var val in entity.Attributes)
                        //{
                        //    if (dtCol.Rows.Count < 1)
                        //    {
                        //        //retItems.Entities.Count
                        //        for (int x = 0; x < 3; x++)
                        //        {
                        //            //Console.Write(row[x].ToString() + " ");
                        //            dr["" + val.Key + ""] = val.Value;
                        //            dtCol.Rows.Add(dr["" + val.Key + ""].ToString());
                        //        }
                        //    }
                        //}



                        //DataRow dr = dtCol.NewRow();
                        ////dr["" + entity.Key + ""] = entity.Attributes.Values;
                        ////dtCol.Rows.Add(entity.Attributes.Values);                   
                        ////retItems.Entities.Count
                        //foreach (var val in entity.Attributes)
                        //{
                        //    for (int x = 0; x < retItems.Entities.Count; x++)
                        //    {
                        //        //Console.Write(row[x].ToString() + " ");
                        //        dr["" + val.Key + ""] = entity.Attributes.Values;
                        //        dtCol.Rows.Add(dr[x].ToString());
                        //    }
                        //}

                    }
                    else
                    {

                        rowNr = 0;
                        c = 0;
                        foreach (var val in entity.Attributes)
                        {
                            if (rowNr == 0)
                            {
                                DataRow dr1 = dtCol.NewRow();
                                dr1["" + val.Key + ""] = val.Value;
                                dtCol.Rows.Add(dr1["" + val.Key + ""].ToString());
                                rowNr = rowNr + 1;
                            }else
                            {
                                var r = dtCol.Rows.Count;
                                c = c + 1;
                                //dtCol.Rows[0]["" + val.Key + ""] = val.Value;
                                //dtCol.Rows[r - 1][c - 1] = val.Value;

                                dtCol.Rows[r-1][c] = val.Value;
                                
                            }
                            
                        }
                    }

                    colNr = colNr + 1;


                    

                    //var collection = entity.Attributes.Values;
                    //foreach (var attval in collection)
                    //{

                    //    DataRow dr = dtCol.NewRow();
                    //    dr["" + val.Key + ""] = entity.Attributes.Values;
                    //    dtCol.Rows.Add(dr);
                    //}

                    //var collection = entity.Attributes.Values;
                    //foreach (var attval in collection)
                    //{
                    //    DataRow dr = dtCol.NewRow();
                    //    dr["" + val.Key + ""] = entity.Attributes.Values;
                    //    dtCol.Rows.Add(dr);
                    //}

                    //if (retItems.Entities.Count> 0)
                    //{
                    //    foreach (KeyValuePair<String, Object> attribute in entity.Attributes)
                    //    {
                    //        dtCol.Columns.Add("" + attribute.Key + "");
                    //    }
                    //}

                }
                //foreach (Entity entity in retItems.Entities)
                //{

                //    DataRow dr = dtCol.NewRow();
                //    //dr["" + entity.Key + ""] = entity.Attributes.Values;
                //    //dtCol.Rows.Add(entity.Attributes.Values);                   
                //    //retItems.Entities.Count

                //    for (int x = 0; x < retItems.Entities.Count; x++)
                //    {
                //        //Console.Write(row[x].ToString() + " ");
                //        dr["" + dr[x] + ""] = entity.Attributes.Values;
                //        dtCol.Rows.Add(dr[x].ToString());
                //    }

                //    //foreach (DataRow row in entity.Attributes.Values)
                //    //{
                //    //    //Console.WriteLine();
                //    //    for (int x = 0; x < retItems.Entities.Count; x++)
                //    //    {
                //    //        //Console.Write(row[x].ToString() + " ");
                //    //        dtCol.Rows.Add(row[x].ToString());
                //    //    }
                //    //}


                //    //var collection = entity.Attributes.Values;
                //    //foreach (var attval in collection)
                //    //{

                //    //    DataRow dr = dtCol.NewRow();
                //    //    //dr["" + attval.Key + ""] = entity.Attributes.Values;
                //    //    dtCol.Rows.Add(entity.Attributes.Values);
                //    //}
                //}

                dGV_DataContent.DataSource = dtCol;


                //if (retItems.Entities.Count > 0)
                //{

                //    //var t= (retItems.Entities).Items[0]).Attributes.Keys).Items[0]
                        

                //    //mySqlCnnection.Open();
                //    //string list = "select * from login";
                //    //MySqlDataAdapter dataadapter = new MySqlDataAdapter(list, mySqlCnnection);
                //    //DataSet ds = new DataSet();
                //    //dataadapter.Fill(ds, "" + item + "");
                //    //dGV_DataContent.DataSource = ds.Tables[0];

                //    //string list = "select * from login";
                //    //SqlCommand command = new SqlCommand(list, db.connect());
                //    //SqlDataReader reader = command.ExecuteReader();
                //    //DataTable dt = new DataTable();
                //    //dt.Load(reader);
                //    //dGV_DataContent.DataSource = dt;

                //    DataSet contactData = new DataSet();
                //    DataTable dt = new DataTable();

                //    dt.Columns.Add("ownerid");
                //    dt.Columns.Add("name");
                //    //dt.Columns.Add("cint_soc_sec_no");
                //    //dt.Columns.Add("cint_incident_id");

                    

                //    foreach (var account in retItems.Entities)
                //    {
                //        DataRow dr = dt.NewRow();
                //        dr["ownerid"] = account["ownerid"].ToString();
                //        dr["name"] = account["name"].ToString();
                //        //dr["cint_soc_sec_no"] = contact["cint_soc_sec_no"].ToString();
                //        dt.Rows.Add(dr);


                //        //foreach (DataRow row in account.Attributes)
                //        //{
                //        //    Console.WriteLine();
                //        //    for (int x = 0; x < myTopTenData.Columns.Count; x++)
                //        //    {
                //        //        Console.Write(row[x].ToString() + " ");
                //        //    }
                //        //}

                //    }
                    
                //    dGV_DataContent.DataSource = dt;
                //    //dataGridView1.Databind();

                //    //dt.Fill(ds);
                //    //dataGridView1.DataSource = ds.Tables["Student"].DefaultView;
                //}               


                //linQ

                //RetrieveEntityRequest retrieveEntityRequest = new RetrieveEntityRequest
                //{
                //    RetrieveAsIfPublished = true,
                //    LogicalName = "" + item + "",
                //    EntityFilters = EntityFilters.All

                //};
                //EntityCollection retAccounts = service.RetrieveMultiple(new FetchExpression(fetchXmlaccount));

                //var response = ((RetrieveEntityResponse)service.Execute(retrieveEntityRequest));
                //var resentities1 = response.EntityMetadata;

                //DataTable dt1 = new DataTable();

                //dt1.Columns.Add("LogicalName");

                //foreach (AttributeMetadata allattributes in resentities1.Attributes)
                //{
                //    DataRow dr1 = dt1.NewRow();
                //    dr1["LogicalName"] = allattributes.LogicalName.ToString();
                //    dt1.Rows.Add(dr1);
                //}
                //dGV_DataContent.DataSource = dt1;
            }



        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
