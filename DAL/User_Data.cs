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
        public List<User> DB;
        public string path = @"user.bin";

        public User_Data()
        {
            DB = new List<User>();
            DB.Add(new User("admin", "admin"));
            Encryption.encryption(DB, path);
        }

        public User_Data(List<User> UDB)
        {
            DB = UDB;
            User admin = new User("admin", "admin");
            if (!Contains(admin))
                DB.Add(new User("admin", "admin"));
            Encryption.encryption(DB, path);
        }


        public void Add(Object us)
        {
            User user = (User)us;
            DB.Add(user);
            Encryption.encryption(DB, path);
        }

        public void Remove(Object us)
        {
            User user = (User)us;
            foreach (User u in DB)
            {
                if ((u.userName).CompareTo((user.userName)) == 0 && (u.password).CompareTo((user.password)) == 0)
                {
                    DB.Remove(u);
                    Encryption.encryption(DB, path);
                    return;
                }
            }
        }

        public bool Contains(User user)
        {
            foreach (User u in DB)
            {
                if ((u.userName).CompareTo(user.userName) == 0 && (u.password).CompareTo((user.password)) == 0) return true;
            }
            return false;
        }

        public bool isUserNameTaken(string userName)
        {
            foreach (User u in DB)
            {
                if ((u.userName).CompareTo(userName) == 0) return true;
            }
            return false;
        }
    }
}
