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
    //database for ClubMember, recives information from bl and updates/returns information from the database 
    [Serializable]
    public class ClubMember_Data
    {
        public List<Customer> DB;
        public string path = @"clubMember.bin";

        public ClubMember_Data()
        {
            DB = new List<Customer>();
        }

        public ClubMember_Data(List<Customer> CMDB)
        {
            DB = CMDB;
            Encryption.encryption(DB, path);
        }


        public void Add(Object cm)
        {
            Customer clubMember = (Customer)cm;
            DB.Add(clubMember);
            Encryption.encryption(DB, path);
        }

        public void Remove(string id)
        {
            var clubMember =
                from c in DB
                where c.memberID == id
                select c;
            foreach (Customer c in clubMember)
            {
                DB.Remove(c);
                Encryption.encryption(DB, path);
                return;
            }
        }

        public bool Contains(string id)
        {
            foreach (Customer c in DB)
            {
                if ((c.memberID).CompareTo((id)) == 0) return true;
            }
            return false;
        }

        public string getIDByMemberID(string memberID)
        {
            var id =
                from i in DB
                where i.memberID == memberID
                select i.ID;
            return id.ToString();
        }

        public string getNameByMemberID(string memberID)
        {
            var firstName =
                from i in DB
                where i.memberID == memberID
                select i.firstName;
            var lastName =
                from i in DB
                where i.memberID == memberID
                select i.lastName;
            string name = "";
            foreach (string i in firstName)
            {
                name += i;
                name += " ";
            }
            foreach (string i in lastName)
            {
                name += i;
            }
            if (name == "")
            {
                name = "no club member by this id";
            }
            return name;
        }

        public string getAllClubMembers()
        {
            StringBuilder allClubMembers = new StringBuilder("");
            if (DB.Count() == 0)
            {
                return "there are no club members";
            }
            foreach (Customer c in DB)
            {
                allClubMembers.Append(c.ToString());
                allClubMembers.Append("\r\n");
            }
            return allClubMembers.ToString();
        }

        public string getClubMemberByFirstName(string name)
        {
            StringBuilder ClubMemberByName = new StringBuilder("");
            var firstName =
                from i in DB
                where i.firstName == name
                select i;
            if (firstName.Count() == 0)
            {
                ClubMemberByName.Append("no club members by the first name ");
                ClubMemberByName.Append(name);
            }
            foreach (Customer c in firstName)
            {
                ClubMemberByName.Append(c.ToString());
                ClubMemberByName.Append("\r\n");
            }
            return ClubMemberByName.ToString();
        }
        public string getClubMemberByLastName(string name)
        {
            StringBuilder ClubMemberByName = new StringBuilder("");
            var LastName =
                from i in DB
                where i.lastName == name
                select i;
            if (LastName.Count() == 0)
            {
                ClubMemberByName.Append("no club members by the last name ");
                ClubMemberByName.Append(name);
            }
            foreach (Customer c in LastName)
            {
                ClubMemberByName.Append(c.ToString());
                ClubMemberByName.Append("\r\n");
            }
            return ClubMemberByName.ToString();
        }
        public string getClubMemberByFullName(string fname, string lname)
        {
            StringBuilder ClubMemberByName = new StringBuilder("");
            var FullName =
                from i in DB
                where (i.firstName == fname) && (i.lastName == lname)
                select i;
            if (FullName.Count() == 0)
            {
                ClubMemberByName.Append("no club members by the name ");
                ClubMemberByName.Append(fname);
                ClubMemberByName.Append(lname);
            }
            foreach (Customer c in FullName)
            {
                ClubMemberByName.Append(c.ToString());
            }
            return ClubMemberByName.ToString();
        }

        public string getClubMemberByID(string id)
        {
            StringBuilder ClubMemberByID = new StringBuilder("");
            var clubMember =
               from c in DB
               where (c.ID == id)
               select c;
            foreach (Customer c in clubMember)
            {
                ClubMemberByID.Append(c.ToString());
            }
            return ClubMemberByID.ToString();
        }

        public string getTrnsactionHistoryByMemberID(string memberID)
        {
            if (!Contains(memberID))
            {
                return "No club member by this id";
            }
            StringBuilder transactionHistory = new StringBuilder("");
            var transaction =
                from t in DB
                where t.memberID == memberID
                select t;
            foreach (Customer c in transaction)
            {
                transactionHistory.Append(c.transaction.ToString());
            }
            if (transactionHistory.ToString() == "")
            {
                transactionHistory.Append("no transaction history");
                transactionHistory.Append("\r\n");
            }
            return transactionHistory.ToString();
        }
        public bool updateClubMember(string id, string firstName, string lastName, string gender, string birthDay)
        {
            if (!Contains(id))
            {
                return false;
            }
            var clubMember =
               from c in DB
               where (c.ID == id)
               select c;
            foreach (Customer c in clubMember)
            {
                c.firstName = firstName;
                c.lastName = lastName;
                c.gender = gender;
                c.dateOfBirth = birthDay;
            }
            Encryption.encryption(DB, path);
            return true;
        }

        public void removeTransaction(string id)
        {
            foreach (Customer c in DB)
            {
                foreach (Transaction t in c.transaction)
                {
                    if (t.transactionID == id)
                    {
                        c.transaction.Remove(t);
                    }
                }
            }
        }
    }
}
