using PSDLab.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDLab.View
{
    public partial class DeleteCart : System.Web.UI.Page
    {
        private readonly CartRepository cartRepo = new CartRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["albumId"] != null)
                {
                    if (int.TryParse(Request.QueryString["albumId"], out int albumIdToDelete))
                    {
                        // Call the removeCarts method from the cartRepo instance
                        cartRepo.removeCarts(albumIdToDelete);

                        // Display a success message
                        messageLabel.Text = "Item removed from cart successfully.";
                        Response.Redirect("~/View/CartPage.aspx");
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
