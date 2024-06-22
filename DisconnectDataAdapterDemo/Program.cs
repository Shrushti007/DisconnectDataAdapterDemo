using BusinessLogicLibrary;
using HelperLibrary;

namespace DisconnectDataAdapterDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.show \n2.Insert \n3.Find \n4.Delete \n5.Update");
            int ch=Convert.ToInt32(Console.ReadLine());
            CustomerHelper helper = new CustomerHelper();

            switch (ch)
            {
                case 1:
                    List<CustomerBAL> list = new List<CustomerBAL>();
                    list=helper.GetCustomers();
                    foreach (var item in list)
                    {
                        Console.WriteLine(item.Customerid);
                        Console.WriteLine(item.CustName);
                    }
                    break;
                case 2:
                    CustomerBAL c = new CustomerBAL();
                    c.Customerid = 6;
                    c.CustName = "Shankari";
                    helper.InsertCustomer(c);
                    break;
                case 3:
                    CustomerBAL d = new CustomerBAL();
                    d=helper.FindCustomer(1);
                    Console.WriteLine(d.Customerid);
                    Console.WriteLine(d.CustName);
                    break;
                case 4:
                    helper.DeleteCustomer(4);
                    break;
                default:
                    break;

            }
        }
    }
}