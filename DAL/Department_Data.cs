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
    //database for department, recives information from bl and updates/returns information from the database 
    [Serializable]
    public class Department_Data
    {
        public List<Backend.Department> DB;
        public EmartDataContext emartDataContext;

        public Department_Data()
        {
            DB = new List<Backend.Department>();
            DB.Add(new Backend.Department("defult", "0"));//defult department, only in use when removing departmetnt in exsisting object
            emartDataContext = new EmartDataContext();
        }

        public Department_Data(List<Backend.Department> DDB)
        {
            DB = DDB;
            emartDataContext = new EmartDataContext();

        }


        public bool contains(string id)
        {
            foreach (Backend.Department d in DB)
            {
                if ((d.ID) == id) return true;
            }
            return false;
        }

        public bool isNameTaken(string name)
        {
            foreach (Backend.Department d in DB)
            {
                if ((d.name) == name) return true;
            }
            return false;
        }

        public void Add(Backend.Department d)
        {
            DB.Add(d);
            DAL.Department temp = Change.DepartmentBackendToDal(d);
            emartDataContext.Departments.InsertOnSubmit(temp);
            emartDataContext.SubmitChanges();
        }

        public Boolean Remove(string id)
        {
            Backend.Department temp = new Backend.Department();
            foreach (Backend.Department d in DB)
            {
                if (d.ID == id)
                {
                    temp = d;
                }
            }
            DB.Remove(temp);
            foreach (DAL.Department d in emartDataContext.Departments)
            {
                if (d.ID == id)
                {
                    emartDataContext.Departments.DeleteOnSubmit(d);
                    emartDataContext.SubmitChanges();
                    return true;
                }
            }
            return false;
        }
        public void RemoveByName(String name)
        {
            Backend.Department temp=new Backend.Department();
           
            foreach (Backend.Department d in DB)
            {
                if (d.name == name)
                {
                    temp = d;
                }
            }
            DB.Remove(temp);
            foreach (DAL.Department d in emartDataContext.Departments)
            {
                if (d.name == name)
                {
                    emartDataContext.Departments.DeleteOnSubmit(d);
                    emartDataContext.SubmitChanges();
                }
            }
        }

        public string getDepartmentByName(string Name)
        {
            StringBuilder department = new StringBuilder("");
            var dByName =
                from i in DB
                where (i.name).CompareTo(Name) == 0
                select i;
            foreach (Backend.Department d in dByName)
            {
                department.Append(d.ToString());
                department.Append("\r\n");
            }
            if (department.ToString() == "")
            {
                department.Append("no departments by this name");
            }
            return department.ToString();
        }

        public string getDepartmentByID(string id)
        {
            StringBuilder department = new StringBuilder("");
            var dByID =
                from i in DB
                where i.ID == id
                select i;
            foreach (Backend.Department d in dByID)
            {
                department.Append(d.ToString());
                department.Append("\r\n");
            }
            if (department.ToString() == "")
            {
                department.Append("no departments by this id");
            }
            return department.ToString();
        }
        public string getAllDepartmentString()
        {
            StringBuilder AllDepartment = new StringBuilder("");
            if (DB.Count() == 0)
            {
                return "there are no departments";
            }
            foreach (Backend.Department d in DB)
            {
                AllDepartment.Append(d.ToString());
                AllDepartment.Append("\r\n");
            }
            return AllDepartment.ToString();
        }

        public List<Backend.Department> getAllDepartment()
        {
            List<Backend.Department> list = new List<Backend.Department>();
            foreach (Backend.Department d in DB)
            {
                list.Add(d);
            }
            return list;
        }
    }
}
