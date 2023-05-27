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
    public partial class EditArtist : System.Web.UI.Page
    {
        DatabaseEntities db = SingletonDatabase.GetInstance();
        ArtistRepository ar = new ArtistRepository();
        HomeRepository hr = new HomeRepository();
        ArtistValidation av = new ArtistValidation();
        public int currentId;
        public string oldName;
        public int visitorRole;
        protected void Page_Load(object sender, EventArgs e)
        {
            string artistName = Request.QueryString["artistName"];
            if(artistName == null)
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

                Artist currentArtist = ar.getArtistByName(artistName);
                oldName = currentArtist.artistName;
                currentLabel.Text = currentArtist.artistName;
                artistImage.ImageUrl = currentArtist.artistImage;
                currentId = currentArtist.artistId;
            }

            
        }

        protected void uploadBtn_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text;
            if(name != oldName && !av.validateName(name))
            {
                uploadStatus.Text = "Name already exist.";
            }
            else if (imageUpload.HasFile)
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(imageUpload.FileName);
                string filePath = Server.MapPath("~/Image/Artist/" + fileName);

                imageUpload.SaveAs(filePath);

                string imagePath = "/Image/Artist/" + fileName;

                Artist currentArtist = ar.getArtistByID(currentId);
                currentArtist.artistName = name;
                currentArtist.artistImage = imagePath;

                db.SaveChanges();

                Response.Redirect("~/View/HomePage.aspx");
                uploadStatus.Text = "Success";
            }
            else
            {
                uploadStatus.Text = "Name and Image must be filled.";
            }
        }
    }
}