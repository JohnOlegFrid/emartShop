using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;


namespace Backend
{
    //object representataion of a sestem user
    [Serializable]
    public class User
    {
        private string _userName;
        private string _password;
        private string _ID;

        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string userName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        [XmlElement("Password")]
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        public User(string name, string password, string ID)
        {
            _userName = name;
            _password = password;
            _ID = ID;
        }
    }
}
