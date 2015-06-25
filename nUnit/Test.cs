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
        public void a()
        { //@ Add a deparment and check if it existing
            Backend.Department dp = new Backend.Department("Computers", "123123");
            Department_Data dt = new Department_Data();
            dt.Add(dp);
            Assert.IsTrue(dt.contains(dp.ID));
        }

        [Test] // #2
        public void b()
        { //@ Add a deparment and check if it existing
            Backend.Department dp = new Backend.Department("Games", "12341234");
            Department_Data dt = new Department_Data();
            dt.Add(dp);
            Assert.IsTrue(dt.contains(dp.ID));
        }

        [Test] // #3
        public void c()
        { //@ Add a product and check if it existing
            Backend.Product dp = new Backend.Product("pentium",Backend.Product.Type.electronics,"1","123123",true,200,200.0);
            Product_Data dt = new Product_Data();
            dt.Add(dp);
            Assert.IsTrue(dt.Contains(dp.inventoryID));
        }

        [Test] // #4
        public void d()
        { //@ Add a product and check if it existing
            Backend.Product dp = new Backend.Product("GTA", Backend.Product.Type.toys, "3", "12341234", true, 200, 200.0);
            Product_Data dt = new Product_Data();
            dt.Add(dp);
            Assert.IsTrue(dt.Contains(dp.inventoryID));
        }

        [Test] // #5
        public void e()
        { //@ Add a product and check if he existing
            Backend.Product dp = new Backend.Product("Soldiers", Backend.Product.Type.toys, "4", "12341234", true, 200, 200.0);
            Product_Data dt = new Product_Data();
            dt.Add(dp);
            Assert.IsTrue(dt.Contains(dp.inventoryID));
        }

        [Test] // #6
        public void f()
        { //@ Remove a product and check if removed
            Product_Data dt = new Product_Data();
            dt.Remove("1");
            Assert.IsTrue(!dt.Contains("1"));
        }


        [Test] // #7
        public void g()
        { //@ Remove a product and check if removed
            Product_Data dt = new Product_Data();
            dt.Remove("2");
            Assert.IsTrue(!dt.Contains("1"));
        }

        [Test] // #8
        public void h()
        { //@ Remove a product and check if removed
            Product_Data dt = new Product_Data();
            dt.Remove("3");
            Assert.IsTrue(!dt.Contains("1"));
        }

        [Test] // #9
        public void i()
        { //@ Remove a product and check if removed
            Product_Data dt = new Product_Data();
            dt.Remove("4");
            Assert.IsTrue(!dt.Contains("1"));
        }

        [Test] // #10
        public void j()
        { //@ Remove a Department and check if removed
            Department_Data dt = new Department_Data();
            dt.Remove("123123");
            Assert.IsTrue(!dt.contains("123123"));
        }

        [Test] // #11
        public void k()
        { //@ Remove a Department and check if removed
            Department_Data dt = new Department_Data();
            dt.Remove("12341234");
            Assert.IsTrue(!dt.contains("12341234"));
        }

        [Test] // #12
        public void l()
        { //@ Add a deparment and check if he existing
            ClubMember_Data cd = new ClubMember_Data();
            Backend.Club_Member c = new Club_Member("12", "a", "a", "Man", "12", "01.03.1988");
            cd.Add(c);
            Assert.IsTrue(cd.Contains("12"));
        }
        

        [Test] // #13
        public void m()
        { //@ Add a deparment and check if he existing
            ClubMember_Data cd = new ClubMember_Data();
            cd.Remove("12");
            Assert.IsTrue(!cd.Contains("12"));
        }

        [Test] // #14
        public void n()
        { //@ Add a deparment and check if it existing
            Backend.Department dp = new Backend.Department("Music", "3434");
            Department_Data dt = new Department_Data();
            dt.Add(dp);
            Assert.IsTrue(dt.contains(dp.ID));
        }

        [Test] // #15
        public void o()
        { //@ Add a worker and check if he existing
            Employee_Data ed = new Employee_Data();
            Backend.Employee c = new Backend.Employee("14", "adam", "bon", "Man", "3434", 20000.0, "0", "Worker");
            ed.Add(c);
            Assert.IsTrue(ed.Contains("14"));
        }

        [Test] // #16
        public void p()
        { //@ Add a deparment and check if he existing
            Employee_Data ed = new Employee_Data();
            ed.Remove("14");
            Assert.IsTrue(!ed.Contains("14"));
        }

        [Test] // #17
        public void q()
        { //@ Remove a Department and check if removed
            Department_Data dt = new Department_Data();
            dt.Remove("3434");
            Assert.IsTrue(!dt.contains("3434"));
        }

        [Test] // #18
        public void r()
        { //@ check user creation
            User_Data ud = new User_Data();
            Backend.User u = new Backend.User("a", "a", "112233");
            ud.Add(u);
            Assert.IsTrue(ud.Contains(u));
        }

        [Test] // #19
        public void s()
        { //@ check taken function
            User_Data ud = new User_Data();
            Assert.IsTrue(ud.isUserNameTaken("a"));
        }

        [Test] // #20
        public void t()
        { //@ check delete user
            User_Data ud = new User_Data();
            Backend.User u = new Backend.User("a", "a", "112233");
            ud.Remove(u);
            Assert.IsTrue(!ud.Contains(u));
        }
    }
}
