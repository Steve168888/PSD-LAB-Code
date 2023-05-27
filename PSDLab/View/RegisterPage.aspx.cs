using PSDLab.Controller;
using PSDLab.Factory;
using PSDLab.Model;
using PSDLab.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDLab.View
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        DatabaseEntities db = SingletonDatabase.GetInstance();
        CustomerValidation cv = new CustomerValidation();
        CustomerFactory cf = new CustomerFactory();
        CustomerRepository cr = new CustomerRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text;
            string email = emailBox.Text;
            string gender = GenderRadio.SelectedValue;
            string pass = passBox.Text;
            string address = addressBox.Text;

            if (!cv.validateName(name))
            {
                errorLabel.Text = "Name must be filled and between 5 and 50 characters.";
            }
            else if (!cv.validateGender(gender))
            {
                errorLabel.Text = "Gender must be selected.";
            }
            else if(!cv.validatePassword(pass))
            {
                errorLabel.Text = "Password must be filled.";
            }
            else if (!cv.validateAddress(address))
            {
                errorLabel.Text = "Address must be filled and ends with ‘Street’.";
            }
            else
            {
                Customer user = cr.FindByEmail(email);


                if (user == null)
                {
                    int nextId = (db.Customers.Max(c => c.customerId)) + 1;
                    Customer newCustomer = cf.CreateCustomer(nextId, name, email, gender, pass, address);

                    cr.registerCustomer(newCustomer);

                    errorLabel.Text = "Register Success.";
                }
                else
                {
                    errorLabel.Text = "Email already used.";
                }
            }

            
        }
    }
}