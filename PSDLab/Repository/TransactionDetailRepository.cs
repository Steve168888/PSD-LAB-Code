using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSDLab.Model;
using PSDLab.Factory;

namespace PSDLab.Repository
{
    public class TransactionDetailRepository
    {
        public static DatabaseEntities db = new DatabaseEntities();

        public static void AddTransactionDetail(int TransactionId, int AlbumId, int qty)
        {
            var existingTransactionDetail = db.TransactionDetails
                .SingleOrDefault(td => td.transactionId == TransactionId && td.albumId == AlbumId);

            if (existingTransactionDetail == null)
            {
                // Tambahkan TransactionDetail baru
                db.TransactionDetails.Add(new TransactionDetail
                {
                    transactionId = TransactionId,
                    albumId = AlbumId,
                    Qty = qty
                });

                db.SaveChanges();

            }
        }

        public static dynamic GetTransactionDetails(int TransactionId)
        {
            return db.TransactionDetails.Where(x => x.transactionId == TransactionId).ToList();
        }
    }
}