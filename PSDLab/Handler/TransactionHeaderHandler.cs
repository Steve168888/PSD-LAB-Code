using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSDLab.Repository;

namespace PSDLab.Handler
{
    public class TransactionHeaderHandler
    {
        public static void AddTransactionHeader(DateTime TransactionDate, int CustomerId)
        {
            TransactionHeaderRepository.AddTransactionHeader(TransactionDate, CustomerId);
        }

        public static dynamic createTransactionHeader(DateTime TransactionDate, int CustomerId)
        {
            return TransactionHeaderRepository.createTransactionHeader(TransactionDate, CustomerId);
        }


        public static int GetLastTransactionId(int CustomerId)
        {
            return TransactionHeaderRepository.GetLastTransactionId(CustomerId);
        }

        public static dynamic GetTransactionHeaderbyId(int TransactionId)
        {
            return TransactionHeaderRepository.GetTransactionHeaderbyId(TransactionId);
        }

        public static dynamic GetTransactionHeader(int CustomerId)
        {
            return TransactionHeaderRepository.GetTransactionHeader(CustomerId);
        }

        public static dynamic GetAllTansactionHeader()
        {
            return TransactionHeaderRepository.GetAllTansactionHeader();
        }
    }
}