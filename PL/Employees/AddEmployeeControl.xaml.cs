﻿using System;
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

namespace PL.Employees
{
    /// <summary>
    /// Interaction logic for AddEmployeeControl.xaml
    /// </summary>
    public partial class AddEmployeeControl : UserControl
    {
        BL_Manager BL_manager;

        public AddEmployeeControl(BL_Manager BL_manager)
        {
            this.BL_manager = BL_manager;
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            String fname = firstNametxt.Text;
            String lname = lastNametxt.Text;
            String IDnumber = IDnumbertxt.Text;
            String salary = salarytxt.Text;
            String supervisorID = supervisorIDtxt.Text;
            String departmentID = departmentIDtxt.Text;
            String gender = (gendertxt.SelectedValue as ComboBoxItem).Content.ToString();
            Boolean goodInput = false;
            SimpleProgressBar sb = new SimpleProgressBar();
            //sb.Show();
            // sb.run();
            goodInput = (MainWindow.isWord(fname) && MainWindow.isWord(lname) && MainWindow.isNumber(IDnumber) && MainWindow.isNumber(salary) && MainWindow.isNumber(supervisorID) && MainWindow.isNumber(departmentID));
            if (MainWindow.isWord(fname) && MainWindow.isWord(lname) && MainWindow.isNumber(IDnumber) && MainWindow.isNumber(salary) && MainWindow.isNumber(supervisorID) && MainWindow.isNumber(departmentID))
                goodInput = true;
            if (goodInput && BL_manager.BL_employee.Add(IDnumber, fname, lname, gender, departmentID, salary, supervisorID))
            {
                MessageBox.Show("The employee " + fname + " " + lname + " added succefully", "Added succefully", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
            else
            {
                MessageBox.Show("There where a problem adding the employee to the dataBase.\n One or more from the fields is incorrect, please try again", "Problem", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


        }

        




    }
}
