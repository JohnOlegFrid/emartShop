using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend;
using DAL;

namespace BL
{
    [Serializable]
    public class ClubMember_BL
    {
        ClubMember_Data itsDAL;
        //constructor
        public ClubMember_BL(ClubMember_Data dl)
        {
            itsDAL = dl;
        }

        // checks if club member exsits in the database
        public bool exist(string clubMember)
        {
            return itsDAL.Contains(clubMember);
        }
        //adds a club member
        public void Add(Club_Member clubMember)
        {
            if (!exist(clubMember.ID))
            {
                itsDAL.Add(clubMember);
            }
        }

        // removing club member from database
        public void Remove(string memberID)
        {
            if (exist(memberID))
            {
                itsDAL.Remove(memberID);
            }
        }

        /*
         * the qeury functions 
         */

        public string getNameByMemberID(string memberId)
        {
            if (exist(memberId))
            {
                return (itsDAL.getNameByMemberID(memberId));
            }
            else return null;
        }

        public string getAllClubMembers()
        {
            return itsDAL.getAllClubMembers();
        }

        public string getClubMemberByFirstName(string name)
        {
            return itsDAL.getClubMemberByFirstName(name);
        }

        public string getClubMemberByLastname(string name)
        {
            return itsDAL.getClubMemberByLastName(name);
        }

        public string getClubMemberByFullName(string fname, string lname)
        {
            return itsDAL.getClubMemberByFullName(fname, lname);
        }

        public string getClubMemberByID(string id)
        {
            return itsDAL.getClubMemberByID(id);
        }

        public string getTrnsactionHistoryByMemberID(string memberID)
        {
            return itsDAL.getTrnsactionHistoryByMemberID(memberID);
        }

        public bool updateClubMember(string id, string firstName, string lastName, string gender, string birthDay)
        {
            return itsDAL.updateClubMember(id, firstName, lastName, gender, birthDay);
        }

        public void removeTransaction(string id)
        {
            itsDAL.removeTransaction(id);
        }
    }
}
