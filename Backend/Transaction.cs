using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    //object represantation of Transaction
    [Serializable]
    public class Transaction
    {

        private string _transactionID;
        private DateTime _dateTime;
        private bool _isAReturn;
        private Receipt _receipt;
        private PaymentMethod _paymentMethod;
        private String CustomerID;

        public string transactionID
        {
            get { return _transactionID; }
            set { _transactionID = value; }
        }

        public DateTime dateTime
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }

        public bool isAReturn
        {
            get { return _isAReturn; }
            set { _isAReturn = value; }
        }

        public Receipt receipt
        {
            get { return _receipt; }
            set { _receipt = value; }
        }

        public PaymentMethod paymentMethod
        {
            get { return _paymentMethod; }
            set { _paymentMethod = value; }
        }

        public Transaction(string transactionID, DateTime dateTime, bool isAReturn, Receipt receipt, PaymentMethod paymentMethod)
        {
            _transactionID = transactionID;
            _dateTime = dateTime;
            _isAReturn = isAReturn;
            _receipt = receipt;
            _paymentMethod = paymentMethod;
        }

        public override string ToString()
        {
            StringBuilder transaction = new StringBuilder("");
            transaction.Append(_transactionID);
            transaction.Append(" ");
            transaction.Append(_dateTime);
            transaction.Append(" is a return: ");
            transaction.Append(isAReturn);
            transaction.Append("\n\n");
            transaction.Append(receipt.ToString());
            transaction.Append("\n");
            transaction.Append("\nPayment method : " + paymentMethod);
            return transaction.ToString();
        }
    }
}
