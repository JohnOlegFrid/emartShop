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
    [Serializable]
    public class User_Data : IDAL
    {
        public List<Backend.User> DB;
        public EmartDataContext sqlDB;

        public User_Data()
        {
            DB = new List<Backend.User>();
            DB.Add(new Backend.User("admin", "admin", "admin"));
            sqlDB = new EmartDataContext();
      
        }

        public User_Data(List<Backend.User> UDB)
        {
            DB = UDB;
            Backend.User admin = new Backend.User("admin", "admin", "admin");
            if (!Contains(admin))
                DB.Add(admin);
            sqlDB = new EmartDataContext();
        }


        public void Add(Object us)
        {
            Backend.User user = (Backend.User)us;
            DB.Add(user);
            DAL.User toAdd = Change.UserBackendToDal(user);
            sqlDB.Users.InsertOnSubmit(toAdd);
            sqlDB.SubmitChanges();
        }

        public Boolean Remove(Object us)
        {
            Backend.User user = (Backend.User)us;
            foreach (Backend.User u in DB)
            {
                if ((u.userName).CompareTo((user.userName)) == 0 && (u.password).CompareTo((user.password)) == 0)
                {
                    user = u;

                }
            }
            DB.Remove(user);
            foreach (DAL.User u in sqlDB.Users)
            {
                if ((u.userName).CompareTo((user.userName)) == 0 && (u.password).CompareTo((user.password)) == 0)
                {
                    sqlDB.Users.DeleteOnSubmit(u);
                    sqlDB.SubmitChanges();
                    return true;
                }
            }
            return false;
        }

        public Boolean Update(Backend.User toUpdate,String newPass)
        {
            Boolean ans1 = false; 
            Boolean ans2 = false;
            foreach (Backend.User u in DB)
            {
                if (u.userName==toUpdate.userName && u.password==toUpdate.password)
                {
                    u.password = newPass;
                    ans1 = true;
                }
            }
            foreach (DAL.User u in sqlDB.Users)
            {
                if (u.userName == toUpdate.userName && u.password == toUpdate.password)
                {
                    u.password = newPass;
                    sqlDB.SubmitChanges();
                    ans2 = true;
                }
            }
            return ans1 && ans2;
        }


        public bool Contains(Backend.User user)
        {
            foreach (Backend.User u in DB)
            {
                if ((u.userName).CompareTo(user.userName) == 0 && (u.password).CompareTo((user.password)) == 0) return true;
            }
            return false;
        }

        public bool isUserNameTaken(string userName)
        {
            foreach (DAL.User u in sqlDB.Users)
            {
                if ((u.userName).CompareTo(userName) == 0) return true;
            }
            return false;
        }
        
        public List<Backend.User> getAllUsersList()
        {
            List<Backend.User> list = new List<Backend.User>();
            foreach (Backend.User u in DB)
            {
                list.Add(u);
            }
            return list;
        }

        public string getUserByID(string id)
        {
            StringBuilder SupervisorByID = new StringBuilder("");

            foreach (Backend.User e in DB)
            {
                if (e.ID == id)
                {
                    return e.userName;
                }

            }
            return "";
        }

        public string getIDByUser (string user)
        {

            foreach (Backend.User e in DB)
            {
                if (e.userName.CompareTo(user)==0)
                {
                    String b = e.ID;
                    return e.ID;
                }

            }
            return "";
        }

    }
}
