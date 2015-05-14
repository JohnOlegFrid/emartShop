﻿using System;
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

        //removes a user
        public void Remove(User user)
        {
            if (exist(user))
            {
                itsDAL.Remove(user);
            }
        }

        //checks if the username is already in use
        public bool isUserNameTaken(string userName)
        {
            return itsDAL.isUserNameTaken(userName);
        }

        //change the password of the user
        public void changePassword(User user, string newPassword)
        {
            if (exist(user))
            {
                itsDAL.changePassword(user, newPassword);
            }
        }


    }
}
