using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    //object represantation of Employee
    [Serializable]
    public class Employee : Person
    {


        private string _departmentID;
        private double _salary;
        private string _supervisorID;

        public string departmentID
        {
            get { return _departmentID; }
            set { _departmentID = value; }
        }
        public double salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
        public string supervisorID
        {
            get { return _supervisorID; }
            set { _supervisorID = value; }
        }
        public Employee()
        {
        }

        public Employee(string id, string first, string last, string gender, string departmentID, double salary, string supervisorID)
            : base(id, first, last, gender)
        {
            this._departmentID = departmentID;
            this._salary = salary;
            this._supervisorID = supervisorID;
        }

        public Employee(string id, string first, string last, string gender, string departmentID, double salary, string supervisorID, Type type)
            : base(id, first, last, gender, type)
        {
            this._departmentID = departmentID;
            this._salary = salary;
            this._supervisorID = supervisorID;
            
        }



        public Employee(Person p)
            : base(p.ID, p.firstName, p.lastName, p.gender)
        {
        }

        public override string ToString()
        {
            StringBuilder employee = new StringBuilder("");
            employee.Append(firstName);
            employee.Append(" ");
            employee.Append(lastName);
            employee.Append(" ");
            employee.Append(gender);
            employee.Append(" ");
            employee.Append(ID);
            employee.Append(" department: ");
            employee.Append(departmentID);
            employee.Append(" salary: ");
            employee.Append(salary);
            employee.Append(" supervisor: ");
            employee.Append(supervisorID);
            return employee.ToString();
        }

    }
}
