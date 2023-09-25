using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSDLab.Model;

namespace PSDLab.Factory
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail createTransactionDetail(int TransactionId, int AlbumId, int qty)
        {
            return new TransactionDetail
            {
                transactionId = TransactionId,
                albumId = AlbumId,
                Qty = qty
            };
        }
    }
}