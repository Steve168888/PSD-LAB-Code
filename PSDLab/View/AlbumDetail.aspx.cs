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
    public partial class AlbumDetail : System.Web.UI.Page
    {
        public DatabaseEntities db = SingletonDatabase.GetInstance();
        AlbumRepository ar = new AlbumRepository();
        public int visitorRole;
        HomeRepository hr = new HomeRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string albumName = Request.QueryString["albumName"];
                nameLabel.Text = albumName;

                Album currentAlbum = ar.getAlbumByName(albumName);
                albumImage.ImageUrl = currentAlbum.albumImage;
                descLabel.Text = currentAlbum.albumDesc;
                priceLabel.Text = currentAlbum.albumPrice.ToString();
                stockLabel.Text = currentAlbum.albumStock.ToString();

            }
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