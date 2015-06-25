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
        public List<Club_Member> DB;
        EmartDataContext sqlDB;

        public ClubMember_Data()
        {
            DB = new List<Club_Member>();
            sqlDB = new EmartDataContext();
        }

        public ClubMember_Data(List<Club_Member> CMDB)
        {
            DB = CMDB;
            sqlDB = new EmartDataContext();
        }


        public void Add(Object cm)
        {
            Club_Member clubMember = (Club_Member)cm;
            DB.Add(clubMember);
            DAL.Customer c = Change.CustomerBackendToDal(clubMember);
            sqlDB.Customers.InsertOnSubmit(c);
            sqlDB.SubmitChanges();
        }

        public Boolean Remove(string id)
        {
            Club_Member temp = new Club_Member();
            foreach (Club_Member c in DB)
            {
                if (c.ID == id)
                {
                    temp = c;
                }
                
            }
            DB.Remove(temp);
            foreach (Customer c in sqlDB.Customers)
            {
                if (c.ID == id)
                {
                    sqlDB.Customers.DeleteOnSubmit(c);
                    sqlDB.SubmitChanges();
                    return true;
                }
            }
            return false;
        }

        public bool Contains(string id)
        {
            foreach (Customer c in sqlDB.Customers)
            {
                if ((c.ID).CompareTo((id)) == 0) return true;
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

        public string getAllClubMembersString()
        {
            StringBuilder allClubMembers = new StringBuilder("");
            if (DB.Count() == 0)
            {
                return "there are no club members";
            }
            foreach (Club_Member c in DB)
            {
                allClubMembers.Append(c.ToString());
                allClubMembers.Append("\r\n");
            }
            return allClubMembers.ToString();
        }

        public List<Club_Member> getAllClubMembers()
        {
            List<Club_Member> list = new List<Club_Member>();
            foreach (Club_Member c in DB) list.Add(c);
            return list;
        }

        public List<Club_Member> getClubMemberByFirstName(string name)
        {
            List<Club_Member> list = new List<Club_Member>();
            foreach (Club_Member m in DB)
            {
                if (m.firstName == name) list.Add(m);
                
            }
            return list;
        }


        public List<Club_Member> getClubMemberByLastName(string name)
        {
            List<Club_Member> list = new List<Club_Member>();
            foreach (Club_Member m in DB)
            {
                if (m.lastName == name) list.Add(m);
                
            }
            return list;
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
            foreach (Club_Member c in FullName)
            {
                ClubMemberByName.Append(c.ToString());
            }
            return ClubMemberByName.ToString();
        }


        public List<Club_Member> getClubMemberByID(string id)
        {
            List<Club_Member> list = new List<Club_Member>();
            foreach (Club_Member m in DB)
            {
                if (m.ID == id) list.Add(m);

            }
            return list;
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
            foreach (Club_Member c in transaction)
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
        public bool updateClubMember(Club_Member toUpdate)
        {
            if (!Contains(toUpdate.ID))
            {
                return false;
            }
            
            foreach (Club_Member c in DB)
            {
                if (c.ID == toUpdate.ID)
                {
                    c.firstName = toUpdate.firstName;
                    c.lastName = toUpdate.lastName;
                    c.gender = toUpdate.gender;
                    c.dateOfBirth = toUpdate.dateOfBirth;
                }
            }
                
            foreach(Customer temp in sqlDB.Customers)
            {
                if (temp.ID == toUpdate.ID)
                {
                   temp.firstName = toUpdate.firstName;
                   temp.lastName = toUpdate.lastName;     
                   temp.gender = toUpdate.gender;    
                   temp.dateOfBirth = toUpdate.dateOfBirth;
                   sqlDB.SubmitChanges();
                   return true;     
                }
            }
            return true;
        }

        public void removeTransaction(string id)
        {
            foreach (Club_Member c in DB)
            {
                foreach (Backend.Transaction t in c.transaction)
                {
                    if (t.transactionID == id)
                    {
                        c.transaction.Remove(t);
                    }
                }
            }
        }

        public void updateMemberVisa(string id,String i)
        {
            foreach (Customer c in sqlDB.Customers)
            {
                if(c.ID==id)
                {
                    
                   // sqlDB.Customers.DeleteOnSubmit(c);
                    c.visa = i;
                    //sqlDB.Customers.InsertOnSubmit(c);
                    sqlDB.SubmitChanges();
                }
            }
        }

        public string getVisaByID(string id)
        {
            foreach (Customer c in sqlDB.Customers)
            {
                if(c.ID==id)
                {
                    if(c.visa=="")
                    {
                        return "no visa saved";
                    }
                    return c.visa;
                }
            }
            return "";
        }
    }
}
