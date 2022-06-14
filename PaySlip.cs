using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_programming
{
    /// <summary>
    /// This is a payslip class
    /// </summary>
    public class PaySlip
    {
        public Employee Payee { get; }
        public double gross { get; set; }
        public double super { get; set; }
        public double tax { get; set; }
        public double netPay { get; set; } 

        internal double threshold;
        internal double hours;
        
        
        /// <summary>
        /// This is a constructor of the PaySlip class
        /// </summary>
        /// <param name="e">This is an employee object</param>
        /// <param name="hours">This is the number of hours worked</param>
        public PaySlip (Employee e, double hours)
        {
            this.Payee = e;
            this.netPay = e.Rate * hours;
            this.hours = hours;
        }

        public override string ToString()
        {
            return (Payee) + Environment.NewLine +
                "Total Hours Worked: " + hours + Environment.NewLine +
                "Net Payment: " + netPay + Environment.NewLine +
                "Threshold: " + threshold + Environment.NewLine +
                "Super: " + super + Environment.NewLine +
                "Tax: " + tax + Environment.NewLine +
                "Gross Payment: " + gross;

        }

        public string GetPaySlipDetailsCSVHeader()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("EmployeeId,");
            sb.Append("Hours,");
            sb.Append("Rate,");
            sb.Append("Tax Threshold,");
            sb.Append("Gross Pay,");
            sb.Append("Tax,");
            sb.Append("Net Pay,");
            sb.Append("Superannuation" + Environment.NewLine);
            return sb.ToString();
        }

        public string GetPaySlipDetailsCSV()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Payee.Id + ",");
            sb.Append(hours + ",");
            sb.Append(Payee.Rate + ",");
            sb.Append(threshold + ",");
            sb.Append(gross + ",");
            sb.Append(tax + ",");
            sb.Append(netPay + ",");
            sb.Append(super + Environment.NewLine);
            return sb.ToString();
        }

        /// <summary>
        /// Saves the current PaySlip in a file
        /// </summary>
        /// <returns>Returns the file path where the file is saved</returns>
        public string SaveToFile()
        {
            string fileName = "Pay-" + this.Payee.Id + "-" + this.Payee.FirstName + "-" + this.Payee.LastName + "-" + DateTime.Now.ToString("yyyyMMdd-HHmmss.fff") + ".csv";
            string filePath = Directory.GetCurrentDirectory() + "\\Files\\" + fileName;
            StreamWriter sw = new StreamWriter(filePath);

            sw.Write(this.GetPaySlipDetailsCSVHeader());
            sw.Write(this.GetPaySlipDetailsCSV());

            sw.Close();

            return filePath;
        }
    }
}
