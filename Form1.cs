using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OO_programming
{
    public partial class Form1 : Form
    {
        //internal List<Employee> employees = new List<Employee>();
        internal PayCalculator payCalculator = new PayCalculator();
        internal PaySlip p;
        

        /// <summary>
        /// Form constructor gets invoked when the form is loaded, the Employee details are loaded by the form in this method 
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // Add code below to complete the implementation to populate the listBox
            // by reading the employee.csv file into a List of PaySlip objects, then binding this to the ListBox.
            // CSV file format: <employee ID>, <first name>, <last name>, <hourly rate>,<taxthreshold>
            try
            {
                string status;
                status = payCalculator.LoadTaxDetails();
                if (!status.Equals("success")) { MessageBox.Show(status); return; }
                status = payCalculator.LoadEmployeeDetails();
                if (!status.Equals("success")) { MessageBox.Show(status); return; }
                payCalculator.employees.ForEach(e => this.listBox1.Items.Add(e));
            } catch {
                //ignore error
                MessageBox.Show("Error loading the form");
            }

        }

        /// <summary>
        /// This method gets called when the Generate Payslip button is clicked
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event arguments</param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Add code below to complete the implementation to populate the
            // payment summary (textBox2) using the PaySlip and PayCalculatorNoThreshold
            // and PayCalculatorWithThresholds classes object and methods.
            double hours;
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an employee from the list");
                return;
            }

            try
            {
                hours = Double.Parse(textBox1.Text);
            } catch (Exception ex)
            {
                MessageBox.Show("Enter a valid value in the hours worked field");
                return ;
            }

            if (hours < 0)
            {
                MessageBox.Show("Hours can't be negative");
                return;
            }

            p = payCalculator.CalculatePayment(listBox1.SelectedIndex, hours);

            textBox2.Text = p.ToString();

        }


        /// <summary>
        /// This method gets called when the Save Payslip button is clicked
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event arguments</param>
        private void button3_Click(object sender, EventArgs e)
        {
            // Add code below to complete the implementation for saving the
            // calculated payment data into a csv file.
            // File naming convention: Pay_<full name>_<datetimenow>.csv
            // Data fields expected - EmployeeId, Full Name, Hours Worked, Hourly Rate, Tax Threshold, Gross Pay, Tax, Net Pay, Superannuation
            //Store the file location in a variable.


            if (p == null)
            {
                MessageBox.Show("Please generate the payslip first");
                return;
            }

            string filePath = p.SaveToFile();
            MessageBox.Show("Payslip saved successfully.\nFile: " + filePath);

        }
    }
}
