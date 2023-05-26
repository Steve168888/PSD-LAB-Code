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
    public partial class InsertArtist : System.Web.UI.Page
    {
        DatabaseEntities db = SingletonDatabase.GetInstance();
        ArtistFactory af;
        ArtistRepository ar;
        ArtistValidation av;
        protected void Page_Load(object sender, EventArgs e)
        {

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

                int nextId = (db.Artists.Max(c => c.artistId)) + 1;
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