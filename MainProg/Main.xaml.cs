using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BL;
using DAL;
using Backend;
using PL;
using System.IO;
using System.Data.Linq;

namespace MainProg
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            EmartDataContext emartDataContext = new EmartDataContext();
            //data classes of the enities

            List<DAL.User> userSqlDB = (from s in emartDataContext.Users select s).ToList();
            List<Backend.User> userDB = Change.UserDalToBackendList(userSqlDB);
            User_Data user_data = new User_Data(userDB);


            List<DAL.Customer> clubMemberSqlDB = (from s in emartDataContext.Customers select s).ToList();
            List<Club_Member> clubMemberDB = Change.CustomerDalToBackendList(clubMemberSqlDB);
            ClubMember_Data clubMember_data = new ClubMember_Data(clubMemberDB);
            
          
            List<DAL.Department> departmentSqlDB = (from s in emartDataContext.Departments select s).ToList();
            List<Backend.Department> departmentDB = Change.DepartmentDalToBackendList(departmentSqlDB);
            Department_Data department_data = new Department_Data(departmentDB);

            List<DAL.Employee> EmployeeSqlDB = (from s in emartDataContext.Employees select s).ToList();
            List<Backend.Employee> EmployeeDB = Change.EmployeeDalToBackendList(EmployeeSqlDB);
            Employee_Data employee_data = new Employee_Data(EmployeeDB);


            List<DAL.Product> productSqlDB = (from s in emartDataContext.Products select s).ToList();
            List<Backend.Product> productDB = Change.ProductDalToBackendList(productSqlDB);
            Product_Data product_data = new Product_Data(productDB);

            List<DAL.Transaction> transactionSqlDB = (from s in emartDataContext.Transactions select s).ToList();
            List<Backend.Transaction> transactionDB = Change.TransactionDalToBackendList(transactionSqlDB);
            List<DAL.Recipt> reciptSqlDB = (from s in emartDataContext.Recipts select s).ToList();
            List<Backend.Receipt> reciptDB = Change.ReciptDalToBackendList(reciptSqlDB);
            Transaction_Data transaction_data = new Transaction_Data(transactionDB, reciptDB);

            // managers
            DAL_Manager dal_manager = new DAL_Manager(user_data, clubMember_data, department_data, employee_data, product_data, transaction_data);
            BL_Manager BL_manager = new BL_Manager(dal_manager);

            Window mw = new MainWindow(BL_manager);
            mw.Show();
            this.Close();
        }

       
    }
}
