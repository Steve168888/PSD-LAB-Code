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
    public partial class LoginPage : System.Web.UI.Page
    {
        DatabaseEntities db = SingletonDatabase.GetInstance();
        CustomerRepository cr = new CustomerRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            string email = emailBox.Text;
            string pass = passBox.Text;

            Customer user = cr.validateLogin(email, pass);

            if(user != null)
            {
                HttpCookie cookie = new HttpCookie("UserInfo");
                cookie.Value = user.customerId.ToString();
                cookie.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Add(cookie);

                Response.Redirect("~/View/HomePage.aspx");
            }
            else
            {
                errorLabel.Text = "Email or password is incorrect.";
            }
        }
    }
}