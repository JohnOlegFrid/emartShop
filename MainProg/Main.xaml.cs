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
            //data classes of the enities
            
            List<User> userDB = new List<User>();
            Encryption.checkEncryption(userDB, @"user.bin");
            userDB = (List<User>)Encryption.Decryption(@"user.bin");
            User_Data user_data = new User_Data(userDB);

            List<Customer> clubMemberDB = new List<Customer>();
            Encryption.checkEncryption(clubMemberDB, @"clubMember.bin");
            clubMemberDB = (List<Customer>)Encryption.Decryption(@"clubMember.bin");
            ClubMember_Data clubMember_data = new ClubMember_Data(clubMemberDB);

            List<Department> departmentDB = new List<Department>();
            Encryption.checkEncryption(departmentDB, @"department.bin");
            departmentDB = (List<Department>)Encryption.Decryption(@"department.bin");
            Department_Data department_data = new Department_Data(departmentDB);

            List<Employee> employeeDB = new List<Employee>();
            Encryption.checkEncryption(employeeDB, @"employee.bin");
            employeeDB = (List<Employee>)Encryption.Decryption(@"employee.bin");
            Employee_Data employee_data = new Employee_Data(employeeDB);

            List<Product> productDB = new List<Product>();
            Encryption.checkEncryption(productDB, @"product.bin");
            productDB = (List<Product>)Encryption.Decryption(@"product.bin");
            Product_Data product_data = new Product_Data(productDB);

            List<Transaction> transactionDB = new List<Transaction>();
            Encryption.checkEncryption(transactionDB, @"transaction.bin");
            transactionDB = (List<Transaction>)Encryption.Decryption(@"transaction.bin");
            Transaction_Data transaction_data = new Transaction_Data(transactionDB);

            // managers
            DAL_Manager dal_manager = new DAL_Manager(user_data, clubMember_data, department_data, employee_data, product_data, transaction_data);
            BL_Manager BL_manager = new BL_Manager(dal_manager);

            Window mw = new MainWindow(BL_manager);
            mw.Show();
            this.Close();
        }
    }
}
