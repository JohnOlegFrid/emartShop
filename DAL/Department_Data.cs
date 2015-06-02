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
        public List<Department> DB;
        public string path = @"department.bin";

        public Department_Data()
        {
            DB = new List<Department>();
            DB.Add(new Department("defult", "0"));//defult department, only in use when removing departmetnt in exsisting object
        }

        public Department_Data(List<Department> DDB)
        {
            DB = DDB;
            Encryption.encryption(DB, path);
        }


        public bool contains(string id)
        {
            foreach (Department d in DB)
            {
                if ((d.ID) == id) return true;
            }
            return false;
        }

        public bool isNameTaken(string name)
        {
            foreach (Department d in DB)
            {
                if ((d.name) == name) return true;
            }
            return false;
        }

        public string Add(string name, string id)
        {
            DB.Add(new Department(name, id));
            Encryption.encryption(DB, path);
            return id;
        }

        public void Remove(string id)
        {
            foreach (Department d in DB)
            {
                if (d.ID == id)
                {
                    DB.Remove(d);
                    Encryption.encryption(DB, path);
                    return;
                }
            }
        }
        public void RemoveByName(String name)
        {
            foreach (Department d in DB)
            {
                if (d.name == name)
                {
                    DB.Remove(d);
                    Encryption.encryption(DB, path);
                    return;
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
            foreach (Department d in dByName)
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
            foreach (Department d in dByID)
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
            foreach (Department d in DB)
            {
                AllDepartment.Append(d.ToString());
                AllDepartment.Append("\r\n");
            }
            return AllDepartment.ToString();
        }

        public List<Department> getAllDepartment()
        {
            List<Department> list = new List<Department>();
            foreach (Department d in DB)
            {
                list.Add(d);
            }
            return list;
        }
    }
}
