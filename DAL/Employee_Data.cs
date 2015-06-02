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
    //database for employee, recives information from bl and updates/returns information from the database 
    [Serializable]
    public class Employee_Data
    {
        public List<Employee> DB;
        public string path = @"employee.bin";

        public Employee_Data()
        {
            DB = new List<Employee>();
        }

        public Employee_Data(List<Employee> EDB)
        {
            DB = EDB;
            Encryption.encryption(DB, path);
        }

        public bool Contains(string id)
        {
            foreach (Employee e in DB)
            {
                if (e.ID == id) return true;
            }
            return false;
        }

        public void Add(string id, string first, string last, string gender, string departmentID, double salary, string supervisorID)
        {
            DB.Add(new Employee(id, first, last, gender, departmentID, salary, supervisorID));
            Encryption.encryption(DB, path);
        }

        public void Remove(string id)
        {
            var employee =
                from e in DB
                where e.ID == id
                select e;
            foreach (Employee e in employee)
            {
                DB.Remove(e);
                Encryption.encryption(DB, path);
                return;
            }
        }

        public string getEmployeeByIDString(string id)
        {
            StringBuilder EmployeeByID = new StringBuilder("");
            var employee =
                from i in DB
                where i.ID == id
                select i;
            if (employee.Count() == 0)
            {
                EmployeeByID.Append("no employees by this id ");
                EmployeeByID.Append(id);
            }
            foreach (Employee e in employee)
            {
                EmployeeByID.Append(e.ToString());
                EmployeeByID.Append("\r\n");
            }
            return EmployeeByID.ToString();
        }

        public List<Employee> getEmployeeByID(string id)
        {
            List<Employee> list=new List<Employee>();
            var employee =
                from i in DB
                where i.ID == id
                select i;
           
            foreach (Employee e in employee) list.Add(e);
            
            return list;
        }

        public string getAllEmployeesString()
        {
            StringBuilder allEmployees = new StringBuilder("");
            if (DB.Count() == 0)
            {
                return "there are no employees";
            }
            foreach (Employee e in DB)
            {
                allEmployees.Append(e.ToString());
                allEmployees.Append("\r\n");
            }
            return allEmployees.ToString();
        }

        public List<Employee> getAllEmployees()
        {
            return DB;
        }

        public string getSalaryByID(string id)
        {
            StringBuilder SalaryByID = new StringBuilder("");
            var salary =
                from i in DB
                where i.ID == id
                select i;
            if (salary.Count() == 0)
            {
                SalaryByID.Append("no employees by this id ");
                SalaryByID.Append(id);
            }
            foreach (Employee e in salary)
            {
                SalaryByID.Append(e.salary);
                SalaryByID.Append("\r\n");
            }
            return SalaryByID.ToString();
        }

        public string getSupervisorByID(string id)
        {
            StringBuilder SupervisorByID = new StringBuilder("");
            var supervisor =
                from i in DB
                where i.ID == id
                select i;
            if (supervisor.Count() == 0)
            {
                SupervisorByID.Append("no employees by this id ");
                SupervisorByID.Append(id);
            }
            foreach (Employee e in supervisor)
            {
                SupervisorByID.Append(e.supervisorID);
                SupervisorByID.Append("\r\n");
            }
            return SupervisorByID.ToString();
        }

        public string getEmployeesByFirstNameString(string name)
        {
            StringBuilder EmployeeByName = new StringBuilder("");
            var firstName =
                from i in DB
                where i.firstName == name
                select i;
            if (firstName.Count() == 0)
            {
                EmployeeByName.Append("no employees by this first name ");
                EmployeeByName.Append(name);
            }
            foreach (Employee e in firstName)
            {
                EmployeeByName.Append(e.ToString());
                EmployeeByName.Append("\r\n");
            }
            return EmployeeByName.ToString();
        }

        public List<Employee> getEmployeesByFirstName(string name)
        {
            List<Employee> list = new List<Employee>();
            var firstName =
                from i in DB
                where i.firstName == name
                select i;
            
            foreach (Employee e in firstName)
            {
                list.Add(e);
            }
            return list;
        }

        public string getEmployeesByLastNameString(string name)
        {
            StringBuilder EmployeeByName = new StringBuilder("");
            var lastName =
                from i in DB
                where i.lastName == name
                select i;
            if (lastName.Count() == 0)
            {
                EmployeeByName.Append("no employees by this last name ");
                EmployeeByName.Append(name);
            }
            foreach (Employee e in lastName)
            {
                EmployeeByName.Append(e.ToString());
                EmployeeByName.Append("\r\n");
            }
            return EmployeeByName.ToString();
        }


        public List<Employee> getEmployeesByLastName(string name)
        {
            List<Employee> list = new List<Employee>();
            var LastName =
                from i in DB
                where i.lastName == name
                select i;

            foreach (Employee e in LastName)
            {
                list.Add(e);
            }
            return list;
        }

        public string getEmployeesByFullName(string fname, string lname)
        {
            StringBuilder EmployeeByName = new StringBuilder("");
            var fullName =
                from i in DB
                where (i.lastName == lname) && (i.firstName == fname)
                select i;
            if (fullName.Count() == 0)
            {
                EmployeeByName.Append("no employees by this name ");
                EmployeeByName.Append(fname);
                EmployeeByName.Append(" ");
                EmployeeByName.Append(lname);
            }
            foreach (Employee e in fullName)
            {
                EmployeeByName.Append(e.ToString());
                EmployeeByName.Append("\r\n");
            }
            return EmployeeByName.ToString();
        }

        public bool updateEmployee(string id, string first, string last, string gender, string departmentID, string salary, string supervisorID)
        {
            if (!Contains(id))
            {
                return false;
            }
            var employee =
               from e in DB
               where (e.ID == id)
               select e;
            foreach (Employee e in employee)
            {
                e.firstName = first;
                e.lastName = last;
                e.gender = gender;
                e.departmentID = departmentID;
                e.salary = double.Parse(salary);
                e.supervisorID = supervisorID;
            }
            Encryption.encryption(DB, path);
            return true;
        }
        public void RemoveDepartment(string id)
        {
            foreach (Employee e in DB)
            {
                if (e.departmentID == id)
                {
                    e.departmentID = "0";
                }

            }
        }
    }
}
