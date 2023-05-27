using PSDLab.Controller;
using PSDLab.Factory;
using PSDLab.Model;
using PSDLab.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDLab.View
{
    public partial class InsertAlbum : System.Web.UI.Page
    {
        DatabaseEntities db = SingletonDatabase.GetInstance();
        AlbumValidation av = new AlbumValidation();
        AlbumRepository ar = new AlbumRepository();
        AlbumFactory af = new AlbumFactory();
        HomeRepository hr = new HomeRepository();
        public int visitorRole;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string artistName = Request.QueryString["artistName"];
                if (Request.Cookies["UserInfo"] != null)
                {
                    int customerID = Convert.ToInt32(Request.Cookies["UserInfo"].Value);

                    Customer findCustomer = hr.FindCustomerByID(customerID);

                    visitorRole = hr.customerRole(findCustomer);

                    if (visitorRole != 2)
                    {
                        Response.Redirect("~/View/HomePage.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/View/HomePage.aspx");
                }
            }
        }

        protected void uploadBtn_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text;
            string desc = descBox.Text;
            int price = Convert.ToInt32(priceBox.Text);
            int stock = Convert.ToInt32(stockBox.Text);
            string artistName = Request.QueryString["artistName"];
            int artistId = ar.getArtistIDbyName(artistName);

            if (name.Length <= 0 || name.Length >= 50)
            {
                uploadStatus.Text = "Name must be filled and must be less than 50 characters.";
            }
            else if (desc.Length <= 0 || desc.Length >= 255)
            {
                uploadStatus.Text = "Description must be filled and must be less than 255 characters.";
            }
            else if (stock <= 0)
            {
                uploadStatus.Text = "Stock must be filled and must be more than 0";
            }
            else if (price < 100000 || price > 1000000)
            {
                uploadStatus.Text = "Price must be filled and must be between 100000 and 1000000.";
            }

            if (imageUpload.HasFile && av.validateInput(name, desc, price, stock))
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(imageUpload.FileName);
                string filePath = Server.MapPath("~/Image/Album/" + fileName);

                imageUpload.SaveAs(filePath);

                string imagePath = "/Image/Album/" + fileName;

                int nextId = (db.Artists.Max(c => c.artistId)) + 1;
                Album newAlbum = af.CreateAlbum(nextId, name, desc, price, stock, artistId, imagePath);

                ar.registerAlbum(newAlbum);

                uploadStatus.Text = "Success";
            }
            else
            {
                //uploadStatus.Text = "Name must be filled.";
            }
        }
    }
}