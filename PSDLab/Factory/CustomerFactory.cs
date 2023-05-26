using PSDLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDLab.Factory
{
    public class CustomerFactory
    {
        public Customer CreateCustomer(int id, string name, string email, string gender, string pass, string address)
        {
            return new Customer
            {
                customerId = id,
                customerName = name,
                customerEmail = email,
                customerGender = gender,
                customerPassword = pass,
                customerAddress = address,
                customerRole = "cust"
            };
        }
    }
}
