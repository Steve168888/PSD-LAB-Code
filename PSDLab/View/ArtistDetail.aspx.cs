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
    public partial class ArtistDetail : System.Web.UI.Page
    {
        public DatabaseEntities db = SingletonDatabase.GetInstance();
        ArtistRepository ar = new ArtistRepository();
        public int visitorRole, artId;
        public string artistName;
        HomeRepository hr = new HomeRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (visitorRole == 2)
            {
                addAlbumBtn.Visible = true;
            }
            else
            {
                addAlbumBtn.Visible = false;
            }

            if (!IsPostBack)
            {
                artistName = Request.QueryString["artistName"];
                nameLabel.Text = artistName;

                Artist currentArtist = ar.getArtistByName(artistName);
                artistImage.ImageUrl = currentArtist.artistImage;
                artId = currentArtist.artistId;

            }

        }

        public int getArtistID()
        {
            return artId;
        }

        protected void addAlbumBtn_Click(object sender, EventArgs e)
        {
            artistName = Request.QueryString["artistName"];
            Response.Redirect("~/View/InsertAlbum.aspx?artistName=" + artistName);
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
    }
}