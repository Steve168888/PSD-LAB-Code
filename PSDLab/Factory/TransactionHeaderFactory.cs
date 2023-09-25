using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSDLab.Model;

namespace PSDLab.Factory
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader createTransactionHeader(DateTime TransactionDate, int CustomerId)
        {
            return new TransactionHeader
            {
                transactionDate = TransactionDate,
                customerId = CustomerId
            };
        }
    }
}