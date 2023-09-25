using System;
using PSDLab.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDLab.View
{
    public partial class DeleteArtist : System.Web.UI.Page
    {
        ArtistRepository artistRepo = new ArtistRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["artistId"] != null)
                {
                    int artistIdToDelete;

                    if (int.TryParse(Request.QueryString["artistId"], out artistIdToDelete))
                    {
                        // Call the removeArtist method from the artistRepo instance
                        artistRepo.removeArtist(artistIdToDelete);

                        // Display a success message
                        messageLabel.Text = "Artist deleted successfully.";
                        Response.Redirect("~/View/HomePage.aspx");
                    }
                    else
                    {
                        // Handle the case where the artist ID is not a valid integer
                        // Display an error message or perform appropriate error handling
                        messageLabel.Text = "Invalid artist ID.";
                    }
                }
                else
                {
                    // Handle the case where the artist ID is not provided in the query string
                    // Display an error message or perform appropriate error handling
                    messageLabel.Text = "Artist ID not found in the query string.";
                }
            }
        }
    }
    }
