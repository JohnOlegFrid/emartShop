using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend;


namespace DAL
{
    public static class Change
    {

        /////////////////////////////////////////////////  DEPARTMENT CONVERSION
        public static List<Backend.Department> DepartmentDalToBackendList(List<DAL.Department> departmentSqlDB)
        {
            List<Backend.Department> list = new List<Backend.Department>();
            Backend.Department temp;
            foreach (DAL.Department d in departmentSqlDB)
            {
                temp = new Backend.Department();
                temp.ID = d.ID;
                temp.name = d.name;
                list.Add(temp);
            }
            return list;
        }

        public static DAL.Department DepartmentBackendToDal(Backend.Department d)
        {
            DAL.Department ans = new DAL.Department();
            ans.ID = d.ID;
            ans.name = d.name;
            return ans;
        }


        ///////////////////////////////////////////////// EMPLOYEE CONVERSION
        public static List<Backend.Employee> EmployeeDalToBackendList(List<DAL.Employee> SqlDB)
        {
            List<Backend.Employee> list = new List<Backend.Employee>();
            Backend.Employee temp;
            foreach (DAL.Employee d in SqlDB)
            {
                temp = new Backend.Employee();
                temp.departmentID = d.departmentID;
                temp.firstName = d.firstName;
                temp.gender = d.gender;
                temp.ID = d.ID;
                temp.lastName = d.lastName;
                temp.salary = d.salary;
                temp.supervisorID = d.supervisorID;
                temp.type = d.type;
                list.Add(temp);
            }
            return list;
        }

        public static DAL.Employee EmployeeBackendToDal(Backend.Employee d)
        {
            DAL.Employee temp = new DAL.Employee();
         
            temp.departmentID = d.departmentID.ToString();
            temp.firstName = d.firstName.ToString();
            temp.gender = d.gender.ToString();
            temp.ID = d.ID.ToString();
            temp.lastName = d.lastName.ToString();
            temp.salary = d.salary;
            temp.supervisorID = d.supervisorID.ToString();
            temp.type = d.type.ToString();
            return temp;
        }



        ///////////////////////////////////////////////// PRODUCT CONVERTION
        public static List<Backend.Product> ProductDalToBackendList(List<DAL.Product> SqlDB)
        {
            List<Backend.Product> list = new List<Backend.Product>();
            Backend.Product temp;
            foreach (DAL.Product d in SqlDB)
            {
                temp = new Backend.Product();
                temp.departmentID = d.departmentID;
                temp.inStock = d.inStock;
                temp.inventoryID = d.inventoryID;
                temp.isBestSeller = d.isBestSeller;
                temp.name = d.name;
                temp.price = d.price;
                temp.stockCount = d.stockCount;
                var values = Enum.GetValues(typeof(Backend.Product.Type));
                foreach (Backend.Product.Type t in values)
                {
                    if (t.ToString().CompareTo(d.type)==0)
                    {
                        temp.type = t;
                    }
                }

                list.Add(temp);
            }
            return list;
        }

        public static DAL.Product ProductBackendToDal(Backend.Product d)
        {
            DAL.Product temp = new DAL.Product();

            temp.departmentID = d.departmentID;
            temp.inStock = d.inStock;
            temp.inventoryID = d.inventoryID;
            temp.isBestSeller = d.isBestSeller;
            temp.name = d.name;
            temp.price = d.price;
            temp.stockCount = d.stockCount;
            temp.type = d.type.ToString();
            return temp;
        }


        ///////////////////////////////////////////////// User CONVERTION
        public static List<Backend.User> UserDalToBackendList(List<DAL.User> SqlDB)
        {
            List<Backend.User> list = new List<Backend.User>();
            Backend.User temp;
            foreach (DAL.User u in SqlDB)
            {
                temp = new Backend.User(u.userName,u.password,u.ID);
                list.Add(temp);
            }
            return list;
        }

        public static DAL.User UserBackendToDal(Backend.User u)
        {
            DAL.User ans = new DAL.User();
            ans.ID = u.ID;
            ans.userName = u.userName;
            ans.password = u.password;
            return ans;
        }

        ///////////////////////////////////////////////// Customer CONVERTION
        public static List<Backend.Club_Member> CustomerDalToBackendList(List<DAL.Customer> SqlDB)
        {
            List<Backend.Club_Member> list = new List<Backend.Club_Member>();
            Backend.Club_Member temp;
            foreach (DAL.Customer c in SqlDB)
            {
                temp = new Backend.Club_Member();
                temp.dateOfBirth = c.dateOfBirth;
                temp.firstName = c.firstName;
                temp.gender = c.gender;
                temp.ID = c.ID;
                temp.lastName = c.lastName;
                temp.memberID = c.memberID;
                temp.type = c.type;
 
                list.Add(temp);
            }
            return list;
        }

        public static DAL.Customer CustomerBackendToDal(Backend.Club_Member c)
        {
            DAL.Customer temp = new DAL.Customer();

            temp.dateOfBirth = c.dateOfBirth;
            temp.firstName = c.firstName;
            temp.gender = c.gender;
            temp.ID = c.ID;
            temp.lastName = c.lastName;
            temp.memberID = c.memberID;
            temp.type = c.type;
            return temp;
        }
    }
}
    
