using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSDLab.Model;
using PSDLab.Factory;

namespace PSDLab.Repository
{
    public class TransactionHeaderRepository
    {
        public static DatabaseEntities db = new DatabaseEntities();

        public static void AddTransactionHeader(DateTime TransactionDate, int CustomerId)
        {

            db.TransactionHeaders.Add(TransactionHeaderFactory.createTransactionHeader(TransactionDate, CustomerId));
            db.SaveChanges();
        }

        public static dynamic createTransactionHeader(DateTime TransactionDate, int CustomerId)
        {
            TransactionHeader transactionHeader = new TransactionHeader()
            {
                transactionDate = TransactionDate,
                customerId = CustomerId
            };

            return transactionHeader;
        }


        public static int GetLastTransactionId(int CustomerId)
        {
            int lastTransactionId = db.TransactionHeaders
                .Where(th => th.customerId == CustomerId)
                .OrderByDescending(th => th.transactionId)
                .Select(th => th.transactionId)
                .FirstOrDefault();

            return lastTransactionId;
        }

        public static dynamic GetTransactionHeaderbyId(int TransactionId)
        {
            return db.TransactionHeaders.FirstOrDefault(x => x.transactionId == TransactionId);
        }

        public static dynamic GetTransactionHeader(int CustomerId)
        {
            return db.TransactionHeaders.FirstOrDefault(x => x.customerId == CustomerId);
        }

        public static dynamic GetAllTansactionHeader()
        {
            return db.TransactionHeaders.ToList();
        }
    }
}