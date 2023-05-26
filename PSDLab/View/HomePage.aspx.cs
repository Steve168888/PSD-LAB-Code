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
    public partial class HomePage : System.Web.UI.Page
    {
        public DatabaseEntities db = SingletonDatabase.GetInstance();
        public int visitorRole;
        HomeRepository hr = new HomeRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            //List<Artist> artistList = (from a in db.Artists select a).ToList();
            //artistRepeater.DataSource = artistList;
            //artistRepeater.DataBind();
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.Cookies["UserInfo"] != null)
            {
                int customerID = Convert.ToInt32(Request.Cookies["UserInfo"].Value);

                Customer findCustomer = hr.FindCustomerByID(customerID);

                visitorRole = hr.customerRole(findCustomer);
            }
            else
            {
                visitorRole = 1;
            }

            if (visitorRole == 1)
            {
                this.MasterPageFile = "~/View/Navigation-Guest.Master";
            }
            else if (visitorRole == 2)
            {
                this.MasterPageFile = "~/View/Navigation-Admin.Master";
            }
            else if (visitorRole == 3)
            {
                this.MasterPageFile = "~/View/Navigation-Customer.Master";
            }
        }

        //protected void artistBtn_Command(object sender, CommandEventArgs e)
        //{
        //    if (e.CommandName == "SelectArtist")
        //    {
        //        string artistName = e.CommandArgument.ToString();

        //        // Redirect to ArtistDetail.aspx passing the artistName as a query string parameter
        //        Response.Redirect("~/View/ArtistDetail.aspx?artistName=" + artistName);
        //    }
        //}

        //protected void artistBtn_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/View/ArtistDetail.aspx?artistName=" + artistName);
        //}
    }
}