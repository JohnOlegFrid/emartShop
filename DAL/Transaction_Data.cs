using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
namespace DAL
{
    //database for Transaction, recives information from bl and updates/returns information from the database 
    [Serializable]
    public class Transaction_Data
    {
        public List<Transaction> DB;
        public string path = @"transaction.bin";

        public Transaction_Data()
        {
            DB = new List<Transaction>();
        }

        public Transaction_Data(List<Transaction> TDB)
        {
            DB = TDB;
            Encryption.encryption(DB, path);
        }
        public bool Contains(string id)
        {
            return true;
        }

        public void Add(string transactionID, DateTime datetime, bool isAReturn, Receipt receipt, PaymentMethod paymentMethod)
        {
            DB.Add(new Transaction(transactionID, datetime, isAReturn, receipt, paymentMethod));
            Encryption.encryption(DB, path);
        }

        public void Remove(string id)
        {
            var transaction =
              from t in DB
              where t.transactionID == id
              select t;
            foreach (Transaction t in transaction)
            {
                DB.Remove(t);
                Encryption.encryption(DB, path);
                return;
            }
        }

        public bool isAReaturn(string id)
        {
            var transaction =
              from t in DB
              where t.transactionID == id
              select t;
            foreach (Transaction t in transaction)
            {
                if (t.isAReturn)
                {
                    return true;
                }
            }
            return false;
        }

        public string getPaymentMethod(string id)
        {
            var transaction =
              from t in DB
              where t.transactionID == id
              select t;
            StringBuilder p = new StringBuilder("");
            foreach (Transaction t in transaction)
            {
                p.Append(t.paymentMethod);
            }
            return p.ToString();
        }

        public string getReceiptByTransactionID(string id)
        {
            var transaction =
              from t in DB
              where t.transactionID == id
              select t;
            StringBuilder p = new StringBuilder("");
            foreach (Transaction t in transaction)
            {
                p.Append(t.receipt.ToString());
            }
            return p.ToString();
        }

        public string getAllTransactions()
        {
            StringBuilder allTransactions = new StringBuilder("");
            if (DB.Count() == 0)
            {
                return "There are no transactions";
            }
            foreach (Transaction t in DB)
            {
                allTransactions.Append(t.ToString());
                allTransactions.Append("\r\n");
            }
            return allTransactions.ToString();
        }

        public bool updateTransaction(string transactionID, DateTime dateTime, bool isAReturn, PaymentMethod paymentMethod)
        {
            if (!Contains(transactionID))
            {
                return false;
            }
            var transaction =
               from p in DB
               where (p.transactionID == transactionID)
               select p;
            foreach (Transaction t in transaction)
            {
                t.dateTime = dateTime;
                t.isAReturn = isAReturn;
                t.paymentMethod = paymentMethod;
            }
            Encryption.encryption(DB, path);
            return true;
        }

    }
}
