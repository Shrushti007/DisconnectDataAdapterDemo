using System.Collections.Generic;
using BusinessLogicLibrary;
using DataBaseLibrary;

namespace HelperLibrary
{
    public class CustomerHelper
    {
        CustomerDAL dal = new CustomerDAL();
        public List<CustomerBAL> GetCustomers()
        {
            List<CustomerBAL> custlist=  new List<CustomerBAL>();
            return custlist;
        }


        public void InsertCustomer(CustomerBAL cust) { 
        dal.InsertCustomer(cust);
        }

        public void DeleteCustomer(int id)
        {
            dal.DeleteCustomer(id); 
        }

        public CustomerBAL FindCustomer(int id)
        {
            return dal.FindCustomer(id);
        }
    }
}