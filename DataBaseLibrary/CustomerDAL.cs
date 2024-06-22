using System.Data;
using BusinessLogicLibrary;
using Microsoft.Data.SqlClient;

namespace DataBaseLibrary
{
    public class CustomerDAL
    {
        static string cnstring = "Data Source=CDACLAB-127;Initial Catalog=Shopping;User ID=sa;Password=123456;TrustServerCertificate=true";
        
        DataSet ds = null;
        public List<CustomerBAL> GetCustomers()
        {
            DataSet ds = ConnectAndGetData();
            DataTable dt =ds.Tables["dt_Customer"];//In DataSet we have DataTable
            List<CustomerBAL> custsList = new List<CustomerBAL>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomerBAL cust = new CustomerBAL();
                cust.Customerid = Convert.ToInt32(dt.Rows[i]["Customerid"]);
                cust.CustName = dt.Rows[i]["CustomerName"].ToString();
                custsList.Add(cust);
            }
            return custsList;
        }

        public void InsertCustomer(CustomerBAL cust)
        {
            DataSet ds = ConnectAndGetData();
            DataRow drow = ds.Tables["dt_customer"].NewRow();
            drow["CustomerId"]=cust.Customerid;
            drow["CustomerName"]=cust.CustName;
            ds.Tables["dt_customer"].Rows.Add(drow);
            ConnectandUpdateServer(ds);
            


        }
        private static void ConnectandUpdateServer(DataSet ds)
        {
            SqlConnection cn = new SqlConnection(cnstring);
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Customer", cn);
            SqlCommandBuilder bldr = new SqlCommandBuilder(da);
            da.Update(ds.Tables["dt_Customer"]);
        }

        private static DataSet ConnectAndGetData()
        {

            SqlConnection cn = new SqlConnection(cnstring);
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Customer", cnstring);

            //after query fire(not come under select query bring that element..)
            //We use this to find the record
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey; //primarykey
            //before dataset
            DataSet ds=new DataSet();
            da.Fill(ds, "dt_Customer");//DataTable in dataset. name of dataset is dt_customer
            return ds;
        }

        public void DeleteCustomer(int id)
        {
            DataSet ds=ConnectAndGetData();
            DataRow drow=ds.Tables["dt_Customer"].Rows.Find(id);
            drow.Delete();
            ConnectandUpdateServer(ds);
            
        }
        public CustomerBAL FindCustomer(int id)
        {
            DataSet ds=ConnectAndGetData();
            DataRow drow = ds.Tables["dt_Customer"].Rows.Find(id);
            CustomerBAL customer = new CustomerBAL();
            customer.Customerid =Convert.ToInt32(drow["Customerid"]);
            customer.CustName = drow["CustomerName"].ToString();
            return customer;

        }
       
    }
}