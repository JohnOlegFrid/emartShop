using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend;
using DAL;

namespace BL
{
    [Serializable]
    public class Transaction_BL
    {
        Transaction_Data itsDAL;

        public Transaction_BL(Transaction_Data dl)
        {
            itsDAL = dl;
           // this.Add(false, new Dictionary<string, double> { { "apple", 2.4 }, { "blush", 50 } }, "CreditCard");
           // this.Add(false, new Dictionary<string, double> { { "shirt", 99.9 }, { "laptop", 3000 } }, "CreditCard");
        }

        //checks if transaction exsist in database
        public bool exist(string id)
        {
            return itsDAL.Contains(id);
        }

        //id generator
        private static string generateID()
        {
            DateTime date = DateTime.Now;
            string uniqueID = String.Format("{0:0000}{1:00}{2:00}{3:00}{4:00}{5:00}", date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);
            return uniqueID;
        }

        public void Add(bool isAReturn, Dictionary<string, double> receipt, string paymentMethod)
        {
            itsDAL.Add(generateID(), DateTime.Now, isAReturn, new Receipt(receipt), (PaymentMethod)Enum.Parse(typeof(PaymentMethod), paymentMethod));
        }

        public void Remove(string id)
        {
            itsDAL.Remove(id);
        }

        /*
         * query functions for transaction database
         */
        public bool isAReaturn(string id)
        {
            return itsDAL.isAReaturn(id);
        }

        public string getPaymentMethod(string id)
        {
            return itsDAL.getPaymentMethod(id);
        }

        public string getReceiptByTransactionID(string id)
        {
            return itsDAL.getReceiptByTransactionID(id);
        }

        public string getAllTransactions()
        {
            return itsDAL.getAllTransactions();
        }

        public bool updateTransaction(string transactionID, string dateTime, bool isAReturn, string paymentMethod)
        {
            return itsDAL.updateTransaction(transactionID, Convert.ToDateTime(dateTime), isAReturn, (PaymentMethod)Enum.Parse(typeof(PaymentMethod), paymentMethod));
        }

        public List<Transaction> getTransactionByMonth(int p)
        {
            var transaction =
              from t in itsDAL.DB
              where t.dateTime.Month == p
              select t;
            List<Transaction> list = new List<Transaction>();
            foreach (Transaction t in transaction)
            {
                list.Add(t);
            }
            return list;
        }
    }
}
