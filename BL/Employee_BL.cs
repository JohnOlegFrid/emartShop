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
    public class Employee_BL
    {
        public Employee_Data itsDAL;

        public Employee_BL(Employee_Data dl)
        {
            itsDAL = dl;
        }

        //checks if employee exsists in the database
        public bool exist(string employee)
        {
            return itsDAL.Contains(employee);
        }

        //adds a new employee
        public bool Add(string id, string first, string last, string gender, string departmentID, string salary, string supervisorID, string type)
        {
            if (!exist(id))
            {
                Backend.Employee e = new Backend.Employee(id, first, last, gender, departmentID, double.Parse(salary), supervisorID, type);
                itsDAL.Add(e);
                return true;
            }
            return false;
        }

        //removes employee from data
        public Boolean Remove(string id)
        {
            if (exist(id))
            {
                itsDAL.Remove(id);
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         * query functions for employee database
         */
        public string getAllEmployeesString()
        {
            return itsDAL.getAllEmployeesString();
        }

        public List<Backend.Employee> getAllEmployees()
        {
            return itsDAL.getAllEmployees();
        }

        public string getSalaryByID(string id)
        {
            return itsDAL.getSalaryByID(id);
        }

        public string getEmployeeByIDString(string id)
        {
            return itsDAL.getEmployeeByIDString(id);
        }

        public List<Backend.Employee> getEmployeeByID(string id)
        {
            return itsDAL.getEmployeeByID(id);
        }


        public string getSupervisorByID(string id)
        {
            return itsDAL.getSupervisorByID(id);
        }

        public string getEmployeesByFirstNameString(string name)
        {
            return itsDAL.getEmployeesByFirstNameString(name);
        }

        public List<Backend.Employee> getEmployeesByFirstName(string name)
        {
            return itsDAL.getEmployeesByFirstName(name);
        }

        public string getEmployeesByLastNameString(string name)
        {
            return itsDAL.getEmployeesByLastNameString(name);
        }

        public List<Backend.Employee> getEmployeesByLastName(string name)
        {
            return itsDAL.getEmployeesByLastName(name);
        }

        public string getEmployeesByFullName(string fname, string lname)
        {
            return itsDAL.getEmployeesByFullName(fname, lname);
        }

        public bool updateEmployee(string id, string first, string last, string gender, string departmentID, string salary, string supervisorID, string type)
        {
            return itsDAL.updateEmployee(id, first, last, gender, departmentID, salary, supervisorID, type);
        }

        public void RemoveDepartment(string id)
        {
            itsDAL.RemoveDepartment(id);
        }

        public string getType(string ID)
        {
            return itsDAL.getType(ID);
        }

    }
}
