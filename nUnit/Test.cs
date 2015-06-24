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
            Backend.User us = new Backend.User("israel", "pw", "020202020202");
            User_Data ud = new User_Data();
            ud.Add(us);
            Assert.IsTrue(ud.Remove(us));
        }


        [Test] //#2
        public void checkExistsProduct()
        //@ Add a product, remove it and check if he not existing anymore
        {
            Product_Data pd = new Product_Data();
            Backend.Product p = new Backend.Product("creme", Backend.Product.Type.cloths, "1234", "456", true, 10, 50);
            pd.Add(p); // we add pd to the list
            pd.Remove("1234"); // we remove him from the list
            Assert.IsTrue(!pd.Contains("1234")); // we're checking that is inventoryId is not existing
        }

        [Test] // #3
        public void checkExistsUser2()
        //@ Add a user and check if he existing
        {
            Backend.User us = new Backend.User("boli", "pw2", "67891");
            User_Data ud = new User_Data();
            ud.Add(us);
            Assert.IsTrue(ud.Remove(us));
        }

        [Test] //#4
        public void checkUpdateCM()
        //@ Add a ClubMember, and check if we can update him
        {
            Club_Member cm = new Club_Member("12121212", "avi", "dahan", "male", "12121212", "2105");
            ClubMember_Data cd = new ClubMember_Data();
            cd.Add(cm);
            Assert.IsTrue(cd.Remove(cm.ID));
        }


         [Test] // #5
        public void checkDepartment()
        { //@ Add a deparment and check if he existing
            Backend.Department dp = new Backend.Department("bilou", "5874");
            Department_Data dt = new Department_Data();
            dt.Add(dp);
            dt.Remove(dp.ID);
            Assert.IsTrue(dt.contains(dp.ID));
        }

        [Test] // #6
        public void checkClubMember()
        { //@ Add a clubMember and check if he existing
            Club_Member cm = new Club_Member("1234123412341234", "avi", "dahan", "male", "5618", "2105");
            ClubMember_Data cd = new ClubMember_Data();
            cd.Add(cm);
            cd.Remove(cm.ID);
            Assert.IsTrue(cd.Contains(cm.ID));
        }

        [Test] // #7
        public void checkDepartment2()
        { //@ Add a department and check if he existing
            Backend.Department dp = new Backend.Department("food", "1212");
            Department_Data dt = new Department_Data();
            dt.Add(dp);
            dt.Remove(dp.ID);
            Assert.IsTrue(dt.contains(dp.ID));
        }

        [Test] // #8
        public void checkLocation()
        { //@ Add a location and check if it exists
            Backend.StoreLocation s = new Backend.StoreLocation("Israel", "Eilat", "Mall ha yam", "13772983", "112444342");
            DAL.StoreLocation sl = Change.StoreLocationBackendToDal(s);
            Location_Data ld = new Location_Data();
            ld.Add(sl);
            Assert.IsTrue(ld.Remove(sl));
        }




    }
}
