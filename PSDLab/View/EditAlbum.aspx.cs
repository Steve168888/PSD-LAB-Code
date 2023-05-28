using PSDLab.Controller;
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
    public partial class EditAlbum : System.Web.UI.Page
    {
        DatabaseEntities db = SingletonDatabase.GetInstance();
        HomeRepository hr = new HomeRepository();
        public int currentId, visitorRole;
        public string oldName;
        AlbumRepository ar = new AlbumRepository();
        AlbumValidation av = new AlbumValidation();
        protected void Page_Load(object sender, EventArgs e)
        {
            string albumName = Request.QueryString["albumName"];
            if (albumName == null)
            {
                Response.Redirect("~/View/HomePage.aspx");
            }
            if (!IsPostBack)
            {
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

                Album currentAlbum = ar.getAlbumByName(albumName);
                oldName = currentAlbum.albumName;
                albumImage.ImageUrl = currentAlbum.albumImage;
                currentId = currentAlbum.albumId;

                nameBox.Text = currentAlbum.albumName;
                descBox.Text = currentAlbum.albumDesc;
                priceBox.Text = currentAlbum.albumPrice.ToString();
                stockBox.Text = currentAlbum.albumStock.ToString();
            }
        }

        protected void uploadBtn_Click(object sender, EventArgs e)
        {
            string newName = nameBox.Text;
            string newDesc = descBox.Text;
            int newPrice = Convert.ToInt32(priceBox.Text);
            int newStock = Convert.ToInt32(stockBox.Text);

            if (newName != oldName && !av.validateName(newName))
            {
                uploadStatus.Text = "Name already exist.";
            }
            else if (!av.validateAlbumUpdate(newName, newDesc, newPrice, newStock))
            {
                uploadStatus.Text = "Name, Description, Price, Stock or Image is Invalid.";
            }
            else if (imageUpload.HasFile)
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(imageUpload.FileName);
                string filePath = Server.MapPath("~/Image/Album/" + fileName);

                imageUpload.SaveAs(filePath);

                string imagePath = "/Image/Album/" + fileName;

                Album currentAlbum = ar.getAlbumByID(currentId);
                currentAlbum.albumName = newName;
                currentAlbum.albumDesc = newDesc;
                currentAlbum.albumPrice = newPrice;
                currentAlbum.albumStock = newStock;
                currentAlbum.albumImage = imagePath;

                db.SaveChanges();

                Response.Redirect("~/View/HomePage.aspx");
                uploadStatus.Text = "Success";
            }
            else
            {
                uploadStatus.Text = "Name, Description, Price, Stock and Image must be filled.";
            }
        }
    }
}