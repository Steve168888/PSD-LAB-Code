using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDLab.Controller
{
    public class CustomerValidation
    {
        public bool validateName(string name)
        {
            if (name.Length < 5 || name.Length > 50)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool validateGender(string gender)
        {
            if (gender != "male" && gender != "female")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool validatePassword(string pass)
        {
            if (pass.Length <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool validateAddress(string address)
        {
            bool endsWithStreet = address.EndsWith("Street", StringComparison.OrdinalIgnoreCase);
            if (!endsWithStreet)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}