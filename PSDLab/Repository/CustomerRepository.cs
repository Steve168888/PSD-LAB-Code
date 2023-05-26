using PSDLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDLab.Repository
{
    public class CustomerRepository
    {
        private static DatabaseEntities db = SingletonDatabase.GetInstance();

        public void registerCustomer(Customer customerDetail)
        {
            db.Customers.Add(customerDetail);
            db.SaveChanges();
        }

        public Customer FindByEmail(string email)
        {
            Customer customerFound = (from x in db.Customers where x.customerEmail == email select x).FirstOrDefault();
            return customerFound;
        }

        public Customer validateLogin(string email, string password)
        {
            Customer customerFound = (from x in db.Customers where x.customerEmail == email && x.customerPassword == password select x).FirstOrDefault();
            return customerFound;
        }
    }
}