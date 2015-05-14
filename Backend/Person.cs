using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class Person
    {
        public enum Type
        {
            Administrator,
            Manager,
            Worker,
            Customer
        };

        private string _ID;
        private string _firstName;
        private string _lastName;
        private string _gender;
        private User _user;
        private Type _type;


        public Type type
        {
            get { return _type; }
            set { _type = value; }
        }


        public User user
        {
            get { return _user; }
            set { _user = value; }
        }

        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string firstName
        {
            get { return _firstName; }
            set { _firstName = value; }

        }

        public string lastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public Person()
        {
        }

        public Person(string id, string first, string last, string gender)
        {
            this.ID = id;
            this.firstName = first;
            this.lastName = last;
            this.gender = gender;
        }

        public Person(string id, string first, string last, string gender, Type type)
        {
            this.ID = id;
            this.firstName = first;
            this.lastName = last;
            this.gender = gender;
            this.type = type;
        }

        public Person(Person p)
            : this(p.ID, p.firstName, p.lastName, p.gender)
        {
        }

        public override string ToString()
        {
            return "Full Name: " + firstName + " " + lastName + "\r\n" + "Gender: " + gender + "\r\n" + "ID: " + ID;
        }
    }
}
