﻿using System;
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
        Employee_Data itsDAL;

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
        public bool Add(string id, string first, string last, string gender, string departmentID, string salary, string supervisorID)
        {
            if (!exist(id))
            {
                itsDAL.Add(id, first, last, gender, departmentID, double.Parse(salary), supervisorID);
                return true;
            }
            return false;
        }

        //removes employee from data
        public void Remove(string id)
        {
            if (exist(id))
            {
                itsDAL.Remove(id);
            }
        }

        /*
         * query functions for employee database
         */
        public string getAllEmployees()
        {
            return itsDAL.getAllEmployees();
        }

        public string getSalaryByID(string id)
        {
            return itsDAL.getSalaryByID(id);
        }

        public string getEmployeeByID(string id)
        {
            return itsDAL.getEmployeeByID(id);
        }

        public string getSupervisorByID(string id)
        {
            return itsDAL.getSupervisorByID(id);
        }

        public string getEmployeesByFirstName(string name)
        {
            return itsDAL.getEmployeesByFirstName(name);
        }

        public string getEmployeesBylastName(string name)
        {
            return itsDAL.getEmployeesBylastName(name);
        }

        public string getEmployeesByFullName(string fname, string lname)
        {
            return itsDAL.getEmployeesByFullName(fname, lname);
        }

        public bool updateEmployee(string id, string first, string last, string gender, string departmentID, string salary, string supervisorID)
        {
            return itsDAL.updateEmployee(id, first, last, gender, departmentID, salary, supervisorID);
        }

        public void RemoveDepartment(string id)
        {
            itsDAL.RemoveDepartment(id);
        }

    }
}