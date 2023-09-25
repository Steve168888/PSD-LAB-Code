using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSDLab.Model;
using System.Data;
using PSDLab.Controller;

namespace PSDLab.View
{
    public partial class TransactionPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTransactionHistory();
            }
        }

        private void BindTransactionHistory()
        {
            int customerId = Convert.ToInt32(Request.Cookies["UserInfo"].Value);

            using (var context = new DatabaseEntities())
            {
                var transactionHistory = (from th in context.TransactionHeaders
                                          join td in context.TransactionDetails on th.transactionId equals td.transactionId
                                          join c in context.Customers on th.customerId equals c.customerId
                                          join a in context.Albums on td.albumId equals a.albumId
                                          where c.customerId == customerId
                                          orderby th.transactionDate descending
                                          select new
                                          {
                                              th.transactionId,
                                              th.transactionDate,
                                              c.customerName,
                                              a.albumImage,
                                              a.albumName,
                                              td.Qty,
                                              a.albumPrice,
                                         
                                              TotalPrice = a.albumPrice * td.Qty
                                          }).ToList();

                Repeater1.DataSource = transactionHistory;
                Repeater1.DataBind();
            }
        }
    }
}