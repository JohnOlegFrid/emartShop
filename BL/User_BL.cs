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
        public bool exist(Backend.User user)
        {
            return itsDAL.Contains(user);
        }

        //adds a user to database
        public void Add(Backend.User user)
        {
            if (!exist(user))
            {
                itsDAL.Add(user);
            }
        }

        public Boolean Update(string name,String currPass,String newPass)
        {
            Backend.User u = new Backend.User(name, currPass);
            return itsDAL.Update(u,newPass);
          
        }

        //removes a user
        public Boolean Remove(Backend.User user)
        {
            if (exist(user))
            {
                return itsDAL.Remove(user);
            }
            return false;
        }

        public Boolean RemoveByUserName(String name)
        {
            List<Backend.User> list = itsDAL.getAllUsersList();
            if (isUserNameTaken(name))
            {
                foreach (Backend.User u in list)
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

        public List<Backend.User> getAllUsersList()
        {
            return itsDAL.getAllUsersList();
        }

        public string getUserByID (string ID) 
        {
            return itsDAL.getUserByID(ID);
        }

        public string getIDByUser(string user)
        {
            return itsDAL.getIDByUser(user);
        }

        
    }
}

