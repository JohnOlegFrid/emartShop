using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    //data base class. this class holds refrences to all databases for each entities
    [Serializable]
    public class DAL_Manager : IDAL
    {
        public User_Data userData;
        public ClubMember_Data ClubMemberData;
        public Department_Data departmentData;
        public Employee_Data employeeData;
        public Product_Data productData;
        public Transaction_Data transactionData;
        public Location_Data locationData;
        public void Add(object o){}
        public Boolean Remove(object o){return true;}

        public DAL_Manager(User_Data userData, ClubMember_Data ClubMemberData, Department_Data departmentData, Employee_Data employeeData, Product_Data productData, Transaction_Data transactionData,Location_Data LocationData)
        {
            this.userData = userData;
            this.ClubMemberData = ClubMemberData;
            this.departmentData = departmentData;
            this.employeeData = employeeData;
            this.productData = productData;
            this.transactionData = transactionData;
            this.locationData=LocationData;
        }
        
        

    }
}

