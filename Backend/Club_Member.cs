using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    //object represantation of club member
    [Serializable]
    public class Club_Member : Person
    {

        private string _memberID;
        private List<Transaction> _transaction = new List<Transaction>();
        private String _dateOfBirth;
        private String _type;
        private int _visaNumber;

        public string memberID
        {
            get { return _memberID; }
            set { _memberID = value; }
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

        public String type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int visaNumber
        {
            get { return _visaNumber; }
            set { _visaNumber = value; }
        }

        public Club_Member()
        {
        }

        public Club_Member(string id, string first, string last, string gender, string memberID, String dateOfBirth)
            : base(id, first, last, gender)
        {
            this._memberID = memberID;
            this._dateOfBirth = dateOfBirth;
            this._type = "Customer";
            this._visaNumber = 0;
        }

        public Club_Member(Person p)
            : base(p.ID, p.firstName, p.lastName, p.gender)
        {
            this._type = "Customer";
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
