using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class StoreLocation
    {
        private string _country;

        private string _city;

        private string _street;

        private string _latitude;

        private string _longitude;

        public String country
        {
            get { return _country; }
            set { _country = value; }
        }

        public String city
        {
            get { return _city; }
            set { _city = value; }
        }

        public String street
        {
            get { return _street; }
            set { _street = value; }
        }

        public String latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        public String longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }
       
        public StoreLocation(String country, String city, String street, String latitude, String longitude)
        {
            _country = country;
            _city = city;
            _street = street;
            _latitude = latitude;
            _longitude = longitude;
        }

        public override string ToString()
        {
            StringBuilder ans = new StringBuilder();
            ans.Append(country);
            ans.Append(", ");
            ans.Append(city);
            ans.Append(", ");
            ans.Append(street);
            return ans.ToString();

        }
    }
}
