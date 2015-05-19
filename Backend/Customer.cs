using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    //object represantation of club member
    [Serializable]
    public class Customer : Person
    {

        private string _customerID;
        private List<Transaction> _transaction = new List<Transaction>();
        private String _dateOfBirth;
        private Boolean _clubMember;

        public bool clubMember
        {
            get { return _clubMember; }
            set { if (_clubMember != value) { _clubMember = value; } }       
        }

        public string memberID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }

        public List<Transaction> transaction
        {
            get { return _transaction; }
            set { _transaction = value; }
        }

        public String dateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public Customer()
        {
        }

        public Customer(string id, string first, string last, string gender, string memberID, String dateOfBirth)
            : base(id, first, last, gender, Type.Customer)
        {
            this._customerID = memberID;
            this._dateOfBirth = dateOfBirth;
            this._clubMember = false;
        }

        public Customer(string id, string first, string last, string gender, string memberID, String dateOfBirth, Boolean clubMember)
            : base(id, first, last, gender, Type.Customer)
        {
            this._customerID = memberID;
            this._dateOfBirth = dateOfBirth;
            this._clubMember = clubMember;
        }

        public Customer(Person p)
            : base(p.ID, p.firstName, p.lastName, p.gender)
        {
        }

        public override string ToString()
        {
            StringBuilder clubMember = new StringBuilder("");
            clubMember.Append(ID);
            clubMember.Append(" ");
            clubMember.Append(firstName);
            clubMember.Append(" ");
            clubMember.Append(lastName);
            clubMember.Append(" ");
            clubMember.Append(gender);
            clubMember.Append(" ");
            clubMember.Append(_dateOfBirth);
            return clubMember.ToString();
        }
        public string transactionToString()
        {
            StringBuilder transaction = new StringBuilder("");
            transaction.Append("Transaction: ");
            if (_transaction.Count() != 0)
            {
                foreach (Transaction t in _transaction)
                {
                    transaction.Append(t.ToString());
                }
            }
            else
            {
                transaction.Append("no transaction listed");
            }
            return transaction.ToString();
        }
    }
}
