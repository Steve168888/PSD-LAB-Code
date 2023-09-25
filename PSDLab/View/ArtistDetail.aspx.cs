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
                artId = currentArtist.artistId;
                artistImage.ImageUrl = currentArtist.artistImage;
                artistImage.DataBind();
                List<Album> list = (from x in db.Albums where x.artistId == artId select x).ToList();
                albumRepeater.DataSource = list;
                albumRepeater.DataBind();

            }

        }
        public int getVisitorRole()
        {
            return visitorRole;
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

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            int albumIdToDelete = getArtistID();

            AlbumRepository albumRepository = new AlbumRepository();
            albumRepository.RemoveAlbum(albumIdToDelete);
        }

     

        protected void AddCart_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int albumId = Convert.ToInt32(button.CommandArgument);
            int customerId = Convert.ToInt32(Request.Cookies["UserInfo"].Value);

            CartRepository cartRepository = new CartRepository();
            Cart existingCart = cartRepository.GetCartByAlbumAndCustomer(albumId, customerId);

            if (existingCart != null)
            {
                // The album is already in the cart, so you can show an error message or handle it as per your requirements
                // For example:
                Response.Write("Album is already in the cart!");
            }
            else
            {
                // Create a new cart item and add it to the cart
                Cart newCartItem = new Cart
                {
                    albumId = albumId,
                    customerId = customerId,
                    Qty = 1 // You can set the quantity as per your requirements
                };

                cartRepository.AddToCart(newCartItem);

                // Redirect to the cart page or show a success message
                Response.Redirect("~/View/CartPage.aspx");
            }
        }

        private void RefreshAlbumList()
        {
            artistName = Request.QueryString["artistName"];
            nameLabel.Text = artistName;

            Artist currentArtist = ar.getArtistByName(artistName);
            artId = currentArtist.artistId;
            List<Album> list = (from x in db.Albums where x.artistId == artId select x).ToList();
            albumRepeater.DataSource = list;
            albumRepeater.DataBind();
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            Button deleteButton = (Button)sender;
            RepeaterItem repeaterItem = (RepeaterItem)deleteButton.NamingContainer;
            int albumIdToDelete = Convert.ToInt32(deleteButton.CommandArgument);

            AlbumRepository albumRepository = new AlbumRepository();
            albumRepository.RemoveAlbum(albumIdToDelete);

            // Refresh the album list after deleting
            RefreshAlbumList();
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