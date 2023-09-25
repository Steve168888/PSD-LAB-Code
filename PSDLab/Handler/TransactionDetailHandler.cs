using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSDLab.Repository;

namespace PSDLab.Handler
{
    public class TransactionDetailHandler
    {

        public static void AddTransactionDetail(int TransactionId, int AlbumId, int qty)
        {
            TransactionDetailRepository.AddTransactionDetail(TransactionId, AlbumId, qty);
        }

        public static dynamic GetTransactionDetails(int TransactionId)
        {
            return TransactionDetailRepository.GetTransactionDetails(TransactionId);
        }
    }
}