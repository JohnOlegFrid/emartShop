using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Data.Linq;

namespace DAL
{
    //database for employee, recives information from bl and updates/returns information from the database 
    [Serializable]
    public class Employee_Data
    {
        public List<Backend.Employee> DB;
        public EmartDataContext emartDataContext;
        
        public Employee_Data()
        {
            DB = new List<Backend.Employee>();
            DB.Add(new Backend.Employee("admin", "admin", "admin", "Man", "0", 0.0, "0", "Admin"));
            emartDataContext = new EmartDataContext();
        }

        public Employee_Data(List<Backend.Employee> EDB)
        {
            DB = EDB;
            if (!Contains("admin"))
                DB.Add(new Backend.Employee("admin", "admin", "admin", "Man", "0", 0.0, "0", "Admin"));
            emartDataContext = new EmartDataContext();
        }

        public bool Contains(string id)
        {
            foreach (Backend.Employee e in DB)
            {
                if (e.ID == id) return true;
            }
            return false;
        }

        public void Add(Backend.Employee e)
        {
            DB.Add(e);
            DAL.Employee temp= Change.EmployeeBackendToDal(e);
            emartDataContext.Employees.InsertOnSubmit(temp);
            emartDataContext.SubmitChanges();
        }

        public void Remove(string id)
        {
            var employee =
                from e in DB
                where e.ID == id
                select e;
            foreach (Backend.Employee e in employee)
            {
                DB.Remove(e);
                DAL.Employee temp = Change.EmployeeBackendToDal(e);
                emartDataContext.Employees.DeleteOnSubmit(temp);
                emartDataContext.SubmitChanges();
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
            foreach (Backend.Employee e in employee)
            {
                EmployeeByID.Append(e.ToString());
                EmployeeByID.Append("\r\n");
            }
            return EmployeeByID.ToString();
        }

        public List<Backend.Employee> getEmployeeByID(string id)
        {
            List<Backend.Employee> list = new List<Backend.Employee>();
            var employee =
                from i in DB
                where i.ID == id
                select i;

            foreach (Backend.Employee e in employee) list.Add(e);
            
            return list;
        }

        public string getAllEmployeesString()
        {
            StringBuilder allEmployees = new StringBuilder("");
            if (DB.Count() == 0)
            {
                return "there are no employees";
            }
            foreach (Backend.Employee e in DB)
            {
                allEmployees.Append(e.ToString());
                allEmployees.Append("\r\n");
            }
            return allEmployees.ToString();
        }

        public List<Backend.Employee> getAllEmployees()
        {
            List<Backend.Employee> list = new List<Backend.Employee>();
            foreach (Backend.Employee e in DB)
            {
                list.Add(e);
            }
            return list;
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
            foreach (Backend.Employee e in salary)
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
            foreach (Backend.Employee e in supervisor)
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
            foreach (Backend.Employee e in firstName)
            {
                EmployeeByName.Append(e.ToString());
                EmployeeByName.Append("\r\n");
            }
            return EmployeeByName.ToString();
        }

        public List<Backend.Employee> getEmployeesByFirstName(string name)
        {
            List<Backend.Employee> list = new List<Backend.Employee>();
            var firstName =
                from i in DB
                where i.firstName == name
                select i;

            foreach (Backend.Employee e in firstName)
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
            foreach (Backend.Employee e in lastName)
            {
                EmployeeByName.Append(e.ToString());
                EmployeeByName.Append("\r\n");
            }
            return EmployeeByName.ToString();
        }


        public List<Backend.Employee> getEmployeesByLastName(string name)
        {
            List<Backend.Employee> list = new List<Backend.Employee>();
            var LastName =
                from i in DB
                where i.lastName == name
                select i;

            foreach (Backend.Employee e in LastName)
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
            foreach (Backend.Employee e in fullName)
            {
                EmployeeByName.Append(e.ToString());
                EmployeeByName.Append("\r\n");
            }
            return EmployeeByName.ToString();
        }

        public bool updateEmployee(string id, string first, string last, string gender, string departmentID, string salary, string supervisorID, string type)
        {
            if (!Contains(id))
            {
                return false;
            }

            foreach (Backend.Employee e in DB)
            {
                if(e.ID==id)
                {
                    e.firstName = first;
                    e.lastName = last;
                    e.gender = gender;
                    e.departmentID = departmentID;
                    e.salary = double.Parse(salary);
                    e.supervisorID = supervisorID;
                    e.type = type;
                }
            }

            foreach(DAL.Employee temp in emartDataContext.Employees)
            {
                if(temp.ID==id)
                {
                    temp.firstName = first;
                    temp.lastName = last;
                    temp.gender = gender;
                    temp.departmentID = departmentID;
                    temp.salary = double.Parse(salary);
                    temp.supervisorID = supervisorID;
                    temp.type = type;
                    emartDataContext.SubmitChanges();
                    return true;
                }   
            }
            return false;
        }
        public void RemoveDepartment(string id)
        {
            foreach (Backend.Employee e in DB)
            {
                if (e.departmentID == id)
                {
                    e.departmentID = "0";
                }

            }
        }

        public string getType(string id)
        {
            foreach (Backend.Employee e in DB)
            {
                if (e.ID == id)
                {
                    return e.type;
                }
            }
            return null;
        }



    }
}
