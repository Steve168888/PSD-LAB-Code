using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDLab.View
{
    public partial class Navigation_Customer : System.Web.UI.MasterPage
    {
        public int customerID;
        protected void Page_Load(object sender, EventArgs e)
        {
            customerID = Convert.ToInt32(Request.Cookies["UserInfo"].Value);
        }

        protected void logOutBtn_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["UserInfo"] != null)
            {
                HttpCookie myCookie = new HttpCookie("UserInfo");
                myCookie.Expires = DateTime.Now.AddDays(-100);
                Response.Cookies.Add(myCookie);
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }
        protected void homeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/HomePage.aspx");
        }

        protected void cartBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/CartPage.aspx");
        }
    }
}