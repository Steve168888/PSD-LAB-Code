using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSDLab.Handler;

namespace PSDLab.Controller
{
    public class TransactionDetailController
    {
        public static void AddTransactionDetail(int TransactionId, int AlbumId, int qty)
        {
            TransactionDetailHandler.AddTransactionDetail(TransactionId, AlbumId, qty);
        }

        public static dynamic GetTransactionDetails(int TransactionId)
        {
            return TransactionDetailHandler.GetTransactionDetails(TransactionId);
        }
    }
}