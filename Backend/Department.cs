using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Backend
{
    //object represantation of department
    [Serializable]
    public class Department
    {
        private string _name;
        private string _ID;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public static void Main(String[] arg) { }

        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public Department()
        {

        }

        public Department(string name, string ID)
        {
            _name = name;
            _ID = ID;
        }

        public override string ToString()
        {
            StringBuilder department = new StringBuilder("");
            department.Append(name);
            department.Append(" ");
            department.Append(ID);
            return department.ToString();
        }

       
       
    }
}
