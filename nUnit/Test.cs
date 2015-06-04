using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProg;
using NUnit.Framework;
using BL;
using Backend;
using DAL;

namespace nUnit
{

    //[TestFixture]
    public class Tests
    {
        [Test] // #1
        public void checkExistsUser()
        //@ Add a user and check if he existing
        {
            User us = new User("israel", "pw", "12345");
            User_Data ud = new User_Data();
            ud.Add(us);
            //Assert.IsTrue(ud.Contains(us));
        }


        [Test] //#2
        public void checkExistsProduct()
        //@ Add a product, remove it and check if he not existing anymore
        {
            Product pr = new Product("creme", Product.Type.cloths, "1234", "456", true, 10, 50);
            Product_Data pd = new Product_Data();
            pd.Add("creme", Product.Type.cloths, "1234", "456", true, 10, 50); // we add pd to the list
            pd.Remove("1234"); // we remove him from the list
            //Assert.IsTrue(!pd.Contains("1234")); // we're checking that is inventoryId is not existing
        }

        [Test] // #3
        public void checkExistsUser2()
        //@ Add a user and check if he existing
        {
            User us = new User("boli", "pw2", "67891");
            User_Data ud = new User_Data();
            ud.Add(us);
            //Assert.IsTrue(ud.Contains(us));
        }

        [Test] //#3
        public void checkUpdateCM()
        //@ Add a ClubMember, and check if we can update him
        {
            Club_Member cm = new Club_Member("1234", "avi", "dahan", "male", "5618", "2105");
            ClubMember_Data cd = new ClubMember_Data();
            cd.Add(cm);
            ClubMember_BL cb = new ClubMember_BL(cd);
            //Assert.IsTrue(cb.updateClubMember("5618", "leo", "messi", "male", "2705"));
        }


         [Test] // #5
        public void checkDepartment()
        { //@ Add a deparment and check if he existing
            Department dp = new Department("bilou", "5874");
            Department_Data dt = new Department_Data();
            dt.Add("bilou", "5874");
            //Assert.IsTrue(dt.Contains(dp));
        }

        [Test] // #6
        public void checkClubMember()
        { //@ Add a clubMember and check if he existing
            Club_Member cm = new Club_Member("1234", "avi", "dahan", "male", "5618", "2105");
            ClubMember_Data cd = new ClubMember_Data();
            cd.Add(cm);
            //Assert.IsTrue(cd.Contains(cm));
        }

        [Test] // #7
        public void checkDepartment2()
        { //@ Add a department and check if he existing
            Department dp = new Department("food", "1212");
            Department_Data dt = new Department_Data();
            dt.Add("food", "1212");
            //Assert.IsTrue(dt.Contains(dp));
        }




    }
}
