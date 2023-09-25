using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSDLab.Handler;

namespace PSDLab.Controller
{
    public class TransactionHeaderController
    {
        public static void AddTransactionHeader(DateTime TransactionDate, int CustomerId)
        {
            TransactionHeaderHandler.AddTransactionHeader(TransactionDate, CustomerId);
        }

        public static dynamic createTransactionHeader(DateTime TransactionDate, int CustomerId)
        {
            return TransactionHeaderHandler.createTransactionHeader(TransactionDate, CustomerId);
        }


        public static int GetLastTransactionId(int CustomerId)
        {
            return TransactionHeaderHandler.GetLastTransactionId(CustomerId);
        }

        public static dynamic GetTransactionHeaderbyId(int TransactionId)
        {
            return TransactionHeaderHandler.GetTransactionHeaderbyId(TransactionId);
        }

        public static dynamic GetTransactionHeader(int CustomerId)
        {
            return TransactionHeaderHandler.GetTransactionHeader(CustomerId);
        }

        public static dynamic GetAllTansactionHeader()
        {
            return TransactionHeaderHandler.GetAllTansactionHeader();
        }
    }
}