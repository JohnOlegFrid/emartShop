using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Backend;

namespace BL
{
    [Serializable]
    public class User_BL
    {
        User_Data itsDAL;

        public User_BL(User_Data dl)
        {
            itsDAL = dl;
        }

        //checks if user(password&username) exsists in the database
        public bool exist(User user)
        {
            return itsDAL.Contains(user);
        }

        //adds a user to database
        public void Add(User user)
        {
            if (!exist(user))
            {
                itsDAL.Add(user);
            }
        }

        public Boolean Update(string name,String currPass,String newPass)
        {
            List<User> list = itsDAL.getAllUsersList();
            foreach (User u in list)
            {
                if (u.userName == name && u.password == currPass)
                {
                    u.password = newPass;
                    itsDAL.DB = list;
                    return true;
                }
            }
            return false;
        }

        //removes a user
        public void Remove(User user)
        {
            if (exist(user))
            {
                itsDAL.Remove(user);
            }
        }

        public Boolean RemoveByUserName(String name)
        {
            List<User> list=itsDAL.getAllUsersList();
            if (isUserNameTaken(name))
            {
                foreach (User u in list)
                {
                    if (u.userName == name) itsDAL.Remove(u);
                    return true;
                }
            }
            return false;
        }

        //checks if the username is already in use
        public bool isUserNameTaken(string userName)
        {
            return itsDAL.isUserNameTaken(userName);
        }

        public List<User> getAllUsers()
        {
            return itsDAL.getAllUsers();
        }

        public string getUserByID (string ID) 
        {
            return itsDAL.getUserByID(ID);
        }

        public string getIDByUser(string user)
        {
            return itsDAL.getIDByUser(user);
        }

        public List<User> getAllUsersList()
        {
            return itsDAL.getAllUsersList();
        }
    }
}

