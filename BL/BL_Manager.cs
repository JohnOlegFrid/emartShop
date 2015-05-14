﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Backend;

namespace BL
{
    /**
     * this class represents the bl layer and its diffrent parts
     **/
    [Serializable]
    public class BL_Manager
    {
        public User_BL BL_user;
        public ClubMember_BL BL_clubMember;
        public Department_BL BL_department;
        public Employee_BL BL_employee;
        public Product_BL BL_product;
        public Transaction_BL BL_transaction;

        //constructor
        public BL_Manager(DAL_Manager dal_manager)
        {
            BL_user = new User_BL(dal_manager.userData);
            BL_clubMember = new ClubMember_BL(dal_manager.ClubMemberData);
            BL_department = new Department_BL(dal_manager.departmentData);
            BL_employee = new Employee_BL(dal_manager.employeeData);
            BL_product = new Product_BL(dal_manager.productData);
            BL_transaction = new Transaction_BL(dal_manager.transactionData);
        }
        //this function updates the database in the relevet places after addition of a transaction (adding/ removing products)
        public void addTransaction(Dictionary<string, double> recipt, bool isAReturn)
        {
            if (isAReturn)
            {
                foreach (KeyValuePair<string, double> p in recipt)
                {
                    BL_product.Restock(p.Key, "1");
                }
            }
            else
            {
                foreach (KeyValuePair<string, double> p in recipt)
                {
                    BL_product.Restock(p.Key, "-1");
                }
            }
        }
        //this function updates the database in the relevet places after removing a transaction (updating club member)
        public void RemoveTransaction(string id)
        {
            BL_clubMember.removeTransaction(id);
        }
        //this function updates the database in the relevet places removing a department(updating employee and products)
        public void RemoveDepartment(string id)
        {
            BL_product.RemoveDepartment(id);
            BL_employee.RemoveDepartment(id);
        }
    }
}