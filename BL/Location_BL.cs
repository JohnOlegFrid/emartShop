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

        public Location_BL()
        {
            sqlDB = new EmartDataContext();
        }

       
    }
}
