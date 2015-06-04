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
    //object representataion of a system user
    [Serializable]
    public class User
    {
        private String _userName;
        private String _password;
        private String _ID;

        public String ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public String userName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        [XmlElement("Password")]
        public String password
        {
            get { return _password; }
            set { _password = value; }
        }

        public User(String name, String password)
        {
            _userName = name;
            _password = password;
        }
        public User(String name, String password, String IDD)
        {
            _userName = name;
            _password = password;
            _ID = IDD;
        }
    }
}
