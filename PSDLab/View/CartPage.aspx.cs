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
    public partial class CartPage : System.Web.UI.Page
    {
        public DatabaseEntities db = SingletonDatabase.GetInstance();
        public int visitorRole, customerID;
        public List<Album> listAlbum;
        public List<Cart> albumQty;
        HomeRepository hr = new HomeRepository();
        CartRepository cr = new CartRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserInfo"] != null)
                {
                    customerID = Convert.ToInt32(Request.Cookies["UserInfo"].Value);

                    Customer findCustomer = hr.FindCustomerByID(customerID);

                    visitorRole = hr.customerRole(findCustomer);

                    if (visitorRole != 3)
                    {
                        Response.Redirect("~/View/HomePage.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/View/HomePage.aspx");
                }

                custNameLabel.Text = customerID.ToString();
            }

            listAlbum = cr.getAllCartContent(customerID);
            albumQty = cr.getAlbumQty(customerID);

            //CartView.DataSource = cr.getAllCartContent(customerID);
            //CartView.DataBind();
        }
    }
}