using PSDLab.Controller;
using PSDLab.Factory;
using PSDLab.Handler;
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
    public partial class InsertArtist : System.Web.UI.Page
    {
        DatabaseEntities db = SingletonDatabase.GetInstance();
        ArtistFactory af = new ArtistFactory();
        ArtistRepository ar = new ArtistRepository();
        ArtistValidation av = new ArtistValidation();
        HomeRepository hr = new HomeRepository();
        public int visitorRole;
        protected void Page_Load(object sender, EventArgs e)
        {
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
            }
        }

        protected void uploadBtn_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text.ToString();
            if (imageUpload.HasFile && av.validateName(name))
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(imageUpload.FileName);
                string filePath = Server.MapPath("~/Image/Artist/" + fileName);

                imageUpload.SaveAs(filePath);

                string imagePath = "/Image/Artist/" + fileName;

                int nextId = IdGenerate.GenerateArtistID();
                Artist newArtist = af.CreateArtist(nextId, name, imagePath);

                ar.registerArtist(newArtist);

                uploadStatus.Text = "Success";
            }
            else
            {
                uploadStatus.Text = "Name and Image must be filled.";
            }
        }
    }
}