using PSDLab.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDLab.View
{
    public partial class DeleteAlbum : System.Web.UI.Page
    {
        private readonly AlbumRepository albumRepo = new AlbumRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["albumId"] != null)
                {
                    if (int.TryParse(Request.QueryString["albumId"], out int albumIdToDelete))
                    {
                        // Call the RemoveAlbum method from the albumRepo instance
                        albumRepo.RemoveAlbum(albumIdToDelete);

                        // Display a success message
                        messageLabel.Text = "Album deleted successfully.";
                        Response.Redirect("~/View/HomePage.aspx");
                    }
                    else
                    {
                        // Handle the case where the album ID is not a valid integer
                        // Display an error message or perform appropriate error handling
                        messageLabel.Text = "Invalid album ID.";
                    }
                }
                else
                {
                    // Handle the case where the album ID is not provided in the query string
                    // Display an error message or perform appropriate error handling
                    messageLabel.Text = "Album ID not found in the query string.";
                }
            }
        }
    }
}