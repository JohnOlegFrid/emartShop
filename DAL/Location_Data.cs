using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace DAL
{
    public class Location_Data
    {
        EmartDataContext sqlDB;

        public Location_Data()
        {
            sqlDB = new EmartDataContext();
        }

        public void Add(StoreLocation sl)
        {
            sqlDB.StoreLocations.InsertOnSubmit(sl);
            sqlDB.SubmitChanges();
        }

        public Boolean Remove(StoreLocation sl)
        {
            foreach (StoreLocation s in sqlDB.StoreLocations)
            {
                if (s.latitude == sl.latitude && s.longitude == sl.longitude)
                {
                    sqlDB.StoreLocations.DeleteOnSubmit(s);
                    sqlDB.SubmitChanges();
                    return true;
                }
            }
            return false;
        }

        public List<StoreLocation> getAll()
        {
            List<StoreLocation> list = (from s in sqlDB.StoreLocations select s).ToList();
            return list;           
        }
    }
}
