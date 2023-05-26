using PSDLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDLab.Repository
{
    public class HomeRepository
    {
        static DatabaseEntities db = SingletonDatabase.GetInstance();

        public Customer FindCustomerByID(int id)
        {
            Customer customerFound = (from x in db.Customers where id == x.customerId select x).FirstOrDefault();
            return customerFound;
        }

        public int customerRole(Customer customer)
        {
            if(customer.customerRole == "admin")
            {
                return 2;
            }
            else if(customer.customerRole == "cust")
            {
                return 3;
            }
            else
            {
                return 1;
            }
        }

    }
}