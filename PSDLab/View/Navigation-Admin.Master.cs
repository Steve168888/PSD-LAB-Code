using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDLab.View
{
    public partial class Navigation_Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}