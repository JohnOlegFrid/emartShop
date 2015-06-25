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
        public List<Backend.Transaction> DB;
        public List<Backend.Receipt> receiptDB;
        public EmartDataContext emartDataContext;
        public string path = @"transaction.bin";

        public Transaction_Data()
        {
            DB = new List<Backend.Transaction>();
            receiptDB = new List<Backend.Receipt>();
            emartDataContext = new EmartDataContext();
        }

        public Transaction_Data(List<Backend.Transaction> TDB, List<Backend.Receipt> list)
        {
            DB = TDB;
            receiptDB = list;
            emartDataContext = new EmartDataContext();
            Encryption.encryption(DB, path);
        }
        public bool Contains(string id)
        {
            foreach(Backend.Transaction t in DB)
            {
                if (t.transactionID == id) return true;
            }
            return false;
        }

        public void Add(string transactionID, DateTime datetime, bool isAReturn, string receipt, string paymentMethod, string id)
        {
            DB.Add(new Backend.Transaction(transactionID, datetime, isAReturn, receipt, paymentMethod));
            DAL.Transaction temp = Change.TransactionBackendToDal(new Backend.Transaction(transactionID, datetime, isAReturn, receipt, paymentMethod));
            temp.customerID = id;
            emartDataContext.Transactions.InsertOnSubmit(temp);
            DAL.Recipt_Transaction rt=new Recipt_Transaction();
            rt.reciptID=receipt;
            rt.transactionID=transactionID;
            emartDataContext.Recipt_Transactions.InsertOnSubmit(rt);
            emartDataContext.SubmitChanges();
            Encryption.encryption(DB, path);
        }

        public void Remove(string id)
        {
            var transaction =
              from t in DB
              where t.transactionID == id
              select t;
            foreach (Backend.Transaction t in transaction)
            {
                DB.Remove(t);
                DAL.Transaction temp = Change.TransactionBackendToDal(t);
                emartDataContext.Transactions.DeleteOnSubmit(temp);
                emartDataContext.SubmitChanges();
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
            foreach (Backend.Transaction t in transaction)
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
            foreach (Backend.Transaction t in transaction)
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
            foreach (Backend.Transaction t in transaction)
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
            foreach (Backend.Transaction t in DB)
            {
                allTransactions.Append(t.ToString());
                allTransactions.Append("\r\n");
            }
            return allTransactions.ToString();
        }

        public bool updateTransaction(string transactionID, DateTime dateTime, bool isAReturn, string paymentMethod)
        {
            if (!Contains(transactionID))
            {
                return false;
            }
            var transaction =
               from p in DB
               where (p.transactionID == transactionID)
               select p;
            foreach (Backend.Transaction t in transaction)
            {
                t.dateTime = dateTime;
                t.isAReturn = isAReturn;
                t.paymentMethod = paymentMethod;
            }
            Encryption.encryption(DB, path);
            return true;
        }


        public void addRecipt(Receipt r)
        {
            receiptDB.Add(r);
            DAL.Recipt temp = Change.ReciptBackendToDal(r);
            emartDataContext.Recipts.InsertOnSubmit(temp);
            emartDataContext.SubmitChanges();
        }

        public Backend.Receipt getReciptById(string id)
        {
            var recipt =
              from r in DB
              where r.receipt == id
              select r;
            if(recipt==null)
            {
                return null;
            }
            return recipt as Backend.Receipt;
        }

        public List<Backend.Transaction> getTransactionsByCustomerID(String cusid)
        {
            List <Backend.Transaction> list=new List<Backend.Transaction>();
            foreach (Backend.Transaction t in DB)
            {
                if (t.customerID == cusid) list.Add(t);
            }
            return list;
        }

        public List<Backend.Transaction> getTransactionsByID(String transID)
        {
            List<Backend.Transaction> list = new List<Backend.Transaction>();
            foreach (Backend.Transaction t in DB)
            {
                if (t.transactionID == transID) list.Add(t);
            }
            return list;
        }
    }
}
