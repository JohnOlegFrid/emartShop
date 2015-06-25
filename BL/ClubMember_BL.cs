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
        public ClubMember_Data itsDAL;
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
        public Boolean Add(Club_Member clubMember)
        {
            if (!exist(clubMember.ID))
            {
                itsDAL.Add(clubMember);
                return true;
            }
            return false;
        }
        

        // removing club member from database
        public Boolean Remove(string memberID)
        {
            if (exist(memberID))
            {
                return itsDAL.Remove(memberID);
            }
            return false;
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

        public string getAllClubMembersString()
        {
            return itsDAL.getAllClubMembersString();
        }

        public List<Club_Member> getAllClubMembers()
        {
            return itsDAL.getAllClubMembers();
        }


        public List<Club_Member> getClubMemberByFirstName(string name)
        {
            return itsDAL.getClubMemberByFirstName(name);
        }

        public List<Club_Member> getClubMemberByLastname(string name)
        {
            return itsDAL.getClubMemberByLastName(name);
        }

        public string getClubMemberByFullName(string fname, string lname)
        {
            return itsDAL.getClubMemberByFullName(fname, lname);
        }

        public List<Club_Member> getClubMemberByID(string id)
        {
            return itsDAL.getClubMemberByID(id);
        }

        public string getTrnsactionHistoryByMemberID(string memberID)
        {
            return itsDAL.getTrnsactionHistoryByMemberID(memberID);
        }

        public bool updateClubMember(string id, string firstName, string lastName, string gender, string birthDay)
        {
            Club_Member customer = new Club_Member(id, firstName, lastName, gender, id, birthDay);
            return itsDAL.updateClubMember(customer);
        }

        public void removeTransaction(string id)
        {
            itsDAL.removeTransaction(id);
        }

        public string getVisaByID(string p)
        {
            return itsDAL.getVisaByID(p);
        }

        public void updateMemberVisa(string p, string inf)
        {
            itsDAL.updateMemberVisa(p, inf);
        }
    }
}
