using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using DAL;

namespace BL
{
    public class Location_BL
    {
        EmartDataContext sqlDB;
        Location_Data itsDAL;

        public Location_BL(Location_Data ld)
        {
            itsDAL = ld;
            sqlDB = new EmartDataContext();
        }

       

        public Boolean Add(String country, String city, String street, String latitude, String longitude)
        {
            StoreLocation sl = new StoreLocation();
            sl.city = city;
            sl.latitude = latitude;
            sl.longitude = longitude;
            sl.street = street;
            sl.country = country;
            if (!exist(sl))
            {
                itsDAL.Add(sl);
                return true;
            }
            return false;
        }

        public Boolean Remove(String latitude, String longitude)
        {
            StoreLocation sl = new StoreLocation();
            sl.latitude = latitude;
            sl.longitude = longitude;
            if (exist(sl))
            {
                itsDAL.Remove(sl);
                return true;
            }
            return false;
        }

        public Boolean exist(StoreLocation sl)
        {
            List<StoreLocation> list = itsDAL.getAll();
            foreach (StoreLocation s in list)
            {
                if (s.latitude == sl.latitude && s.longitude == sl.longitude) return true;
            }
            return false;
        }

        public List<Backend.StoreLocation> getAll()
        {
            List<DAL.StoreLocation> list= itsDAL.getAll();
            List<Backend.StoreLocation> ans = Change.StoreLocationDalToBackendList(list);
            return ans;
        }

        public List<Backend.StoreLocation> getByCityName(String city)
        {
            List<DAL.StoreLocation> list = itsDAL.getAll();
            List<Backend.StoreLocation> blist = Change.StoreLocationDalToBackendList(list);
            List<Backend.StoreLocation> ans=new List<Backend.StoreLocation>();
            foreach (Backend.StoreLocation s in blist)
            {
                if (s.city == city) ans.Add(s);
            }
            return ans;
        }

        public List<Backend.StoreLocation> getByCountryName(String country)
        {
            List<DAL.StoreLocation> list = itsDAL.getAll();
            List<Backend.StoreLocation> blist = Change.StoreLocationDalToBackendList(list);
            List<Backend.StoreLocation> ans = new List<Backend.StoreLocation>();
            foreach (Backend.StoreLocation s in blist)
            {
                if (s.country == country) ans.Add(s);
            }
            return ans;
        }
    }
}
